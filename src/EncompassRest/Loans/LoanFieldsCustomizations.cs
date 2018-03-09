﻿using System;
using System.Linq;
using System.Reflection;
using EncompassRest.Utilities;
using Newtonsoft.Json.Serialization;

namespace EncompassRest.Loans
{
    public sealed partial class LoanFields
    {
        private readonly Loan _loan;

        public object this[string fieldId]
        {
            get
            {
                Preconditions.NotNullOrEmpty(fieldId, nameof(fieldId));

                fieldId = fieldId.ToUpper();
                if (fieldId.StartsWith("CX.", StringComparison.Ordinal))
                {
                    var customField = _loan.CustomFields.FirstOrDefault(f => string.Equals(fieldId, f.FieldName, StringComparison.Ordinal));
                    if (customField != null)
                    {
                        if (customField.StringValue != null)
                        {
                            return customField.StringValue;
                        }
                        if (customField.DateValue.HasValue)
                        {
                            return customField.DateValue;
                        }
                        if (customField.NumericValue.HasValue)
                        {
                            return customField.NumericValue;
                        }
                    }
                    return null;
                }
                else
                {
                    var finalProperty = GetFinalProperty(fieldId, out var target);
                    var result = finalProperty.ValueProvider.GetValue(target);
                    var propertyTypeInfo = finalProperty.PropertyType.GetTypeInfo();
                    if (propertyTypeInfo.IsGenericType && !propertyTypeInfo.IsGenericTypeDefinition)
                    {
                        var genericTypeDefinition = propertyTypeInfo.GetGenericTypeDefinition();
                        if (genericTypeDefinition == TypeData.OpenStringEnumValueType || genericTypeDefinition == TypeData.OpenNaType)
                        {
                            result = result.ToString();
                        }
                    }
                    return result;
                }
            }
            set
            {
                Preconditions.NotNullOrEmpty(fieldId, nameof(fieldId));

                fieldId = fieldId.ToUpper();
                if (fieldId.StartsWith("CX.", StringComparison.Ordinal))
                {
                    var customField = _loan.CustomFields.FirstOrDefault(f => string.Equals(fieldId, f.FieldName, StringComparison.Ordinal));
                    if (customField == null)
                    {
                        customField = new CustomField { FieldName = fieldId };
                        _loan.CustomFields.Add(customField);
                    }
                    if (customField.StringValue != null)
                    {
                        customField.StringValue = value?.ToString();
                    }
                    else if (customField.DateValue.HasValue)
                    {
                        customField.DateValue = value != null ? Convert.ToDateTime(value) : (DateTime?)null;
                    }
                    else if (customField.NumericValue.HasValue)
                    {
                        customField.NumericValue = value != null ? Convert.ToDecimal(value) : (decimal?)null;
                    }
                    else
                    {
                        switch (value)
                        {
                            case null:
                                customField.StringValue = null;
                                break;
                            case string str:
                                customField.StringValue = str;
                                break;
                            case DateTime dateTime:
                                customField.DateValue = dateTime;
                                break;
                            default:
                                customField.NumericValue = Convert.ToDecimal(value);
                                break;
                        }
                    }
                }
                else
                {
                    var finalProperty = GetFinalProperty(fieldId, out var target);
                    var destinationValue = value;
                    var propertyType = finalProperty.PropertyType;
                    if (value != null && (propertyType == TypeData<string>.Type || propertyType == TypeData<DateTime?>.Type || propertyType == TypeData<decimal?>.Type || propertyType == TypeData<int?>.Type || propertyType == TypeData<bool?>.Type))
                    {
                        destinationValue = Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyType) ?? propertyType);
                    }
                    else
                    {
                        var propertyTypeContract = JsonHelper.InternalPrivateContractResolver.ResolveContract(propertyType);
                        if (propertyTypeContract.Converter is IStringCreator stringCreator)
                        {
                            destinationValue = stringCreator.Create(value?.ToString());
                        }
                    }
                    finalProperty.ValueProvider.SetValue(target, destinationValue);
                }
            }
        }

        private JsonProperty GetFinalProperty(string fieldId, out object target)
        {
            if (!FieldMappings.TryGetValue(fieldId, out var fieldMapping))
            {
                throw new ArgumentException($"Could not find field {fieldId}");
            }

            var resolver = JsonHelper.InternalPrivateContractResolver;
            target = _loan;
            var currentContract = (JsonObjectContract)resolver.ResolveContract(TypeData<Loan>.Type);
            var propertyNames = fieldMapping.Split('.');
            for (var i = 1; i < propertyNames.Length; ++i)
            {
                var property = currentContract.Properties.GetClosestMatchProperty(propertyNames[i - 1]);
                target = property.ValueProvider.GetValue(target);
                currentContract = (JsonObjectContract)resolver.ResolveContract(property.PropertyType);
            }
            return currentContract.Properties.GetClosestMatchProperty(propertyNames[propertyNames.Length - 1]);
        }

        internal LoanFields(Loan loan)
        {
            _loan = loan;
        }
    }
}