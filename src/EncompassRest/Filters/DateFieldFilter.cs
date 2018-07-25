﻿using System;
using System.ComponentModel;
using EncompassRest.Utilities;
using EnumsNET;
using Newtonsoft.Json;

namespace EncompassRest.Filters
{
    public sealed class DateFieldFilter : FieldFilter
    {
        [JsonRequired]
        public new OrdinalFieldMatchType MatchType { get; }

        [JsonRequired]
        public DateTime Value { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(DateFieldMatchPrecision.Day)]
        public DateFieldMatchPrecision Precision { get; }

        public DateFieldFilter(CanonicalLoanField canonicalLoanField, OrdinalFieldMatchType matchType, DateTime value, DateFieldMatchPrecision precision = DateFieldMatchPrecision.Day)
            : this(canonicalLoanField.Validate(nameof(canonicalLoanField)).GetCanonicalName(), matchType, value, precision)
        {
        }

        public DateFieldFilter(CanonicalContactField canonicalContactField, OrdinalFieldMatchType matchType, DateTime value, DateFieldMatchPrecision precision = DateFieldMatchPrecision.Day)
            : this(canonicalContactField.Validate(nameof(canonicalContactField)).GetCanonicalName(), matchType, value, precision)
        {
        }

        public DateFieldFilter(string canonicalName, OrdinalFieldMatchType matchType, DateTime value, DateFieldMatchPrecision precision = DateFieldMatchPrecision.Day)
            : base(canonicalName)
        {
            matchType.Validate(nameof(matchType));
            precision.Validate(nameof(precision));

            MatchType = matchType;
            Value = value;
            Precision = precision;
        }

        private DateFieldFilter(DateFieldFilter dateFieldFilter)
            : base(dateFieldFilter)
        {
            MatchType = dateFieldFilter.MatchType;
            Value = dateFieldFilter.Value;
        }

        public new DateFieldFilter Clone() => new DateFieldFilter(this);

        protected override FieldFilter CloneFieldFilter() => Clone();

        protected override string GetMatchType() => MatchType.AsString(EnumJsonConverter.CamelCaseNameFormat);

        internal override string GetQueryStringFormat() => $"{CanonicalName}:{MatchType.AsString(EnumFormat.Description)}:{Value}";
    }
}