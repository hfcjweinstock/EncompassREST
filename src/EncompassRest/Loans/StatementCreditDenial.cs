using System;
using System.Collections.Generic;
using EncompassRest.Loans.Enums;
using EncompassRest.Schema;

namespace EncompassRest.Loans
{
    /// <summary>
    /// StatementCreditDenial
    /// </summary>
    public sealed partial class StatementCreditDenial : ExtensibleObject, IIdentifiable
    {
        private DirtyValue<bool?> _additionalStatement;
        /// <summary>
        /// Denial Discl Additional Stmt [DENIAL.X26]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Discl Additional Stmt", OptionsJson = "{\"true\":\"Additional Statement\"}")]
        public bool? AdditionalStatement { get => _additionalStatement; set => _additionalStatement = value; }
        private DirtyValue<bool?> _bankruptcy;
        /// <summary>
        /// Denial Credit - Bankruptcy [DENIAL.X40]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Bankruptcy", OptionsJson = "{\"true\":\"Bankruptcy\"}")]
        public bool? Bankruptcy { get => _bankruptcy; set => _bankruptcy = value; }
        private DirtyValue<bool?> _collateralNotSufficient;
        /// <summary>
        /// Denial Credit - Value or Type of Collateral is Not Sufficient [DENIAL.X80]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Value or Type of Collateral is Not Sufficient", OptionsJson = "{\"true\":\"Value or Type of Collateral is Not Sufficient\"}")]
        public bool? CollateralNotSufficient { get => _collateralNotSufficient; set => _collateralNotSufficient = value; }
        private DirtyValue<bool?> _creditApplicationIncomplete;
        /// <summary>
        /// Denial Other - Credit Appl Incomplete [DENIAL.X57]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Credit Appl Incomplete", OptionsJson = "{\"true\":\"Credit Application Incomplete\"}")]
        public bool? CreditApplicationIncomplete { get => _creditApplicationIncomplete; set => _creditApplicationIncomplete = value; }
        private DirtyValue<bool?> _creditReportObtainedFromConsumerReportingAgency;
        /// <summary>
        /// Denial Discl Info Obtained Your Credit Score from this Consumer Reporting Agency  [DENIAL.X76]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Discl Info Obtained Your Credit Score from this Consumer Reporting Agency ")]
        public bool? CreditReportObtainedFromConsumerReportingAgency { get => _creditReportObtainedFromConsumerReportingAgency; set => _creditReportObtainedFromConsumerReportingAgency = value; }
        private DirtyValue<bool?> _delinquentCreditObligations;
        /// <summary>
        /// Denial Credit - Delinq Credit Oblig [DENIAL.X39]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Delinq Credit Oblig", OptionsJson = "{\"true\":\"Delinquent Credit Obligations\"}")]
        public bool? DelinquentCreditObligations { get => _delinquentCreditObligations; set => _delinquentCreditObligations = value; }
        private DirtyValue<DateTime?> _denialDate;
        /// <summary>
        /// Denial Date [DENIAL.X69]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Date")]
        public DateTime? DenialDate { get => _denialDate; set => _denialDate = value; }
        private DirtyValue<string> _denialDescription;
        /// <summary>
        /// Denial Discl Additional Stmt Detail [DENIAL.X27]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Discl Additional Stmt Detail")]
        public string DenialDescription { get => _denialDescription; set => _denialDescription = value; }
        private DirtyValue<DateTime?> _denialMailedOn;
        /// <summary>
        /// Denial Mailed Date [DENIAL.X11]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Mailed Date")]
        public DateTime? DenialMailedOn { get => _denialMailedOn; set => _denialMailedOn = value; }
        private DirtyValue<bool?> _denialOther1;
        /// <summary>
        /// Denial Other - Other 1 [DENIAL.X65]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Other 1", OptionsJson = "{\"true\":\"-\"}")]
        public bool? DenialOther1 { get => _denialOther1; set => _denialOther1 = value; }
        private DirtyValue<bool?> _denialOther2;
        /// <summary>
        /// Denial Other - Other 2 [DENIAL.X67]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Other 2", OptionsJson = "{\"true\":\"-\"}")]
        public bool? DenialOther2 { get => _denialOther2; set => _denialOther2 = value; }
        private DirtyValue<string> _denialOtherDesc1;
        /// <summary>
        /// Denial Other - Other 1 Descr [DENIAL.X66]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Other 1 Descr")]
        public string DenialOtherDesc1 { get => _denialOtherDesc1; set => _denialOtherDesc1 = value; }
        private DirtyValue<string> _denialOtherDesc2;
        /// <summary>
        /// Denial Other - Other 2 Descr [DENIAL.X68]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Other 2 Descr")]
        public string DenialOtherDesc2 { get => _denialOtherDesc2; set => _denialOtherDesc2 = value; }
        private DirtyValue<string> _deniedBy;
        /// <summary>
        /// Denied By [DENIAL.X70]
        /// </summary>
        [LoanFieldProperty(Description = "Denied By")]
        public string DeniedBy { get => _deniedBy; set => _deniedBy = value; }
        private DirtyValue<bool?> _deniedByFhlmc;
        /// <summary>
        /// Denial - Denied By FHLMC [DENIAL.X53]
        /// </summary>
        [LoanFieldProperty(Description = "Denial - Denied By FHLMC", OptionsJson = "{\"true\":\"Federal Home Loan Mortgage Corporation\"}")]
        public bool? DeniedByFhlmc { get => _deniedByFhlmc; set => _deniedByFhlmc = value; }
        private DirtyValue<bool?> _deniedByFnma;
        /// <summary>
        /// Denial - Denied By FNMA [DENIAL.X52]
        /// </summary>
        [LoanFieldProperty(Description = "Denial - Denied By FNMA", OptionsJson = "{\"true\":\"Federal National Mortgage Association\"}")]
        public bool? DeniedByFnma { get => _deniedByFnma; set => _deniedByFnma = value; }
        private DirtyValue<bool?> _deniedByHud;
        /// <summary>
        /// Denial - Denied By HUD [DENIAL.X50]
        /// </summary>
        [LoanFieldProperty(Description = "Denial - Denied By HUD", OptionsJson = "{\"true\":\"Department of Housing and Urban Dev\"}")]
        public bool? DeniedByHud { get => _deniedByHud; set => _deniedByHud = value; }
        private DirtyValue<bool?> _deniedByOther;
        /// <summary>
        /// Denial - Denied By Other [DENIAL.X54]
        /// </summary>
        [LoanFieldProperty(Description = "Denial - Denied By Other", OptionsJson = "{\"true\":\"-\"}")]
        public bool? DeniedByOther { get => _deniedByOther; set => _deniedByOther = value; }
        private DirtyValue<bool?> _deniedByVa;
        /// <summary>
        /// Denial - Denied By VA [DENIAL.X51]
        /// </summary>
        [LoanFieldProperty(Description = "Denial - Denied By VA", OptionsJson = "{\"true\":\"Department of Veterans Affairs\"}")]
        public bool? DeniedByVa { get => _deniedByVa; set => _deniedByVa = value; }
        private DirtyValue<string> _descriptionofAccount1;
        /// <summary>
        /// Statement of Denial - Description of Account, Transaction or Request Credit Line 1 [DENIAL.X71]
        /// </summary>
        [LoanFieldProperty(Description = "Statement of Denial - Description of Account, Transaction or Request Credit Line 1")]
        public string DescriptionofAccount1 { get => _descriptionofAccount1; set => _descriptionofAccount1 = value; }
        private DirtyValue<string> _descriptionofAccount2;
        /// <summary>
        /// Statement of Denial - Description of Account, Transaction or Request Credit Line 2 [DENIAL.X72]
        /// </summary>
        [LoanFieldProperty(Description = "Statement of Denial - Description of Account, Transaction or Request Credit Line 2")]
        public string DescriptionofAccount2 { get => _descriptionofAccount2; set => _descriptionofAccount2 = value; }
        private DirtyValue<string> _descriptionofAccount3;
        /// <summary>
        /// Statement of Denial - Description of Account, Transaction or Request Credit Line 3 [DENIAL.X73]
        /// </summary>
        [LoanFieldProperty(Description = "Statement of Denial - Description of Account, Transaction or Request Credit Line 3")]
        public string DescriptionofAccount3 { get => _descriptionofAccount3; set => _descriptionofAccount3 = value; }
        private DirtyValue<string> _descriptionofActionTaken1;
        /// <summary>
        /// Statement of Denial - Description of Action Taken Line 1 [DENIAL.X74]
        /// </summary>
        [LoanFieldProperty(Description = "Statement of Denial - Description of Action Taken Line 1")]
        public string DescriptionofActionTaken1 { get => _descriptionofActionTaken1; set => _descriptionofActionTaken1 = value; }
        private DirtyValue<string> _descriptionofActionTaken2;
        /// <summary>
        /// Statement of Denial - Description of Action Taken Line 2 [DENIAL.X75]
        /// </summary>
        [LoanFieldProperty(Description = "Statement of Denial - Description of Action Taken Line 2")]
        public string DescriptionofActionTaken2 { get => _descriptionofActionTaken2; set => _descriptionofActionTaken2 = value; }
        private DirtyValue<string> _ecoaAddress;
        /// <summary>
        /// Denial ECOA Addr [ECOA_ADDR]
        /// </summary>
        [LoanFieldProperty(Description = "Denial ECOA Addr")]
        public string EcoaAddress { get => _ecoaAddress; set => _ecoaAddress = value; }
        private DirtyValue<string> _ecoaAddress2;
        /// <summary>
        /// Denial ECOA Addr2 [ECOA_ADDR2]
        /// </summary>
        [LoanFieldProperty(Description = "Denial ECOA Addr2")]
        public string EcoaAddress2 { get => _ecoaAddress2; set => _ecoaAddress2 = value; }
        private DirtyValue<string> _ecoaCity;
        /// <summary>
        /// Denial ECOA City [ECOA_CITY]
        /// </summary>
        [LoanFieldProperty(Description = "Denial ECOA City")]
        public string EcoaCity { get => _ecoaCity; set => _ecoaCity = value; }
        private DirtyValue<string> _ecoaName;
        /// <summary>
        /// Denial ECOA Name [ECOA_NAME]
        /// </summary>
        [LoanFieldProperty(Description = "Denial ECOA Name")]
        public string EcoaName { get => _ecoaName; set => _ecoaName = value; }
        private DirtyValue<string> _ecoaPhone;
        /// <summary>
        /// Denial ECOA Phone [ECOA_PHONE]
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.PHONE, Description = "Denial ECOA Phone")]
        public string EcoaPhone { get => _ecoaPhone; set => _ecoaPhone = value; }
        private DirtyValue<string> _ecoaPostalCode;
        /// <summary>
        /// Denial ECOA Zip [ECOA_ZIP]
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.ZIPCODE, Description = "Denial ECOA Zip")]
        public string EcoaPostalCode { get => _ecoaPostalCode; set => _ecoaPostalCode = value; }
        private DirtyValue<string> _ecoaState;
        /// <summary>
        /// Denial ECOA State [ECOA_ST]
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.STATE, Description = "Denial ECOA State")]
        public string EcoaState { get => _ecoaState; set => _ecoaState = value; }
        private DirtyValue<bool?> _excessiveObligations;
        /// <summary>
        /// Denial Credit - Excessive Obligations [DENIAL.X35]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Excessive Obligations", OptionsJson = "{\"true\":\"Excessive Obligations\"}")]
        public bool? ExcessiveObligations { get => _excessiveObligations; set => _excessiveObligations = value; }
        private DirtyValue<bool?> _garnishment;
        /// <summary>
        /// Denial Credit - Garnish, Attach, Foreclsr, Repo, Suit [DENIAL.X34]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Garnish, Attach, Foreclsr, Repo, Suit", OptionsJson = "{\"true\":\"Garnishment, Attachment, Foreclosure,\"}")]
        public bool? Garnishment { get => _garnishment; set => _garnishment = value; }
        private DirtyValue<string> _id;
        /// <summary>
        /// StatementCreditDenial Id
        /// </summary>
        public string Id { get => _id; set => _id = value; }
        private DirtyValue<bool?> _inadequateCollateral;
        /// <summary>
        /// Denial Other - Inadequate Collateral [DENIAL.X58]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Inadequate Collateral", OptionsJson = "{\"true\":\"Inadequate Collateral\"}")]
        public bool? InadequateCollateral { get => _inadequateCollateral; set => _inadequateCollateral = value; }
        private DirtyValue<bool?> _informationFromAConsumerReportingAgency;
        /// <summary>
        /// Denial Credit - Info from Credit Rpt Agency [DENIAL.X41]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Info from Credit Rpt Agency", OptionsJson = "{\"true\":\"Information from a Consumer Reporting\"}")]
        public bool? InformationFromAConsumerReportingAgency { get => _informationFromAConsumerReportingAgency; set => _informationFromAConsumerReportingAgency = value; }
        private DirtyValue<bool?> _informationObtainedFromOutsideSource;
        /// <summary>
        /// Denial Discl Info From Other Source [DENIAL.X25]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Discl Info From Other Source", OptionsJson = "{\"true\":\"Information obtained from an outside source other than a consumer reporting agency. You have the right to\"}")]
        public bool? InformationObtainedFromOutsideSource { get => _informationObtainedFromOutsideSource; set => _informationObtainedFromOutsideSource = value; }
        private DirtyValue<bool?> _informationObtainedInReportFromCra;
        /// <summary>
        /// Denial Discl Info Obtained from Credit Rpt Agency [DENIAL.X12]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Discl Info Obtained from Credit Rpt Agency", OptionsJson = "{\"true\":\"Information obtained in a report from a consumer reporting agency:\"}")]
        public bool? InformationObtainedInReportFromCra { get => _informationObtainedInReportFromCra; set => _informationObtainedInReportFromCra = value; }
        private DirtyValue<bool?> _insufficientCreditFile;
        /// <summary>
        /// Denial Credit - Insuff File [DENIAL.X32]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Insuff File", OptionsJson = "{\"true\":\"Insufficient Credit File\"}")]
        public bool? InsufficientCreditFile { get => _insufficientCreditFile; set => _insufficientCreditFile = value; }
        private DirtyValue<bool?> _insufficientCreditReference;
        /// <summary>
        /// Denial Credit - Insuff Reference [DENIAL.X31]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Insuff Reference", OptionsJson = "{\"true\":\"Insufficient Credit Reference\"}")]
        public bool? InsufficientCreditReference { get => _insufficientCreditReference; set => _insufficientCreditReference = value; }
        private DirtyValue<bool?> _insufficientData;
        /// <summary>
        /// Denial Other - Inadequate Collateral Insuff Prpty Info [DENIAL.X60]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Inadequate Collateral Insuff Prpty Info", OptionsJson = "{\"true\":\"Insufficient Data - Property\"}")]
        public bool? InsufficientData { get => _insufficientData; set => _insufficientData = value; }
        private DirtyValue<bool?> _insufficientFundsToCloseLoan;
        /// <summary>
        /// Denial Other - Insuff Funds to Close [DENIAL.X56]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Insuff Funds to Close", OptionsJson = "{\"true\":\"Insufficient Funds to Close the Loan\"}")]
        public bool? InsufficientFundsToCloseLoan { get => _insufficientFundsToCloseLoan; set => _insufficientFundsToCloseLoan = value; }
        private DirtyValue<bool?> _insufficientIncomeForTotalObligations;
        /// <summary>
        /// Denial Credit - Excess Oblig/Insuff Income [DENIAL.X36]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Excess Oblig/Insuff Income", OptionsJson = "{\"true\":\"Insufficient Income for Total Obligations\"}")]
        public bool? InsufficientIncomeForTotalObligations { get => _insufficientIncomeForTotalObligations; set => _insufficientIncomeForTotalObligations = value; }
        private DirtyValue<bool?> _insufficientStabilityOfIncome;
        /// <summary>
        /// Denial Income - Insuff [DENIAL.X45]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Income - Insuff", OptionsJson = "{\"true\":\"Insufficient Stability of Income\"}")]
        public bool? InsufficientStabilityOfIncome { get => _insufficientStabilityOfIncome; set => _insufficientStabilityOfIncome = value; }
        private DirtyValue<bool?> _lackOfCashReserves;
        /// <summary>
        /// Denial Credit - Excess Oblig/Lack Cash Resrvs [DENIAL.X38]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Excess Oblig/Lack Cash Resrvs", OptionsJson = "{\"true\":\"Lack of Cash Reserves\"}")]
        public bool? LackOfCashReserves { get => _lackOfCashReserves; set => _lackOfCashReserves = value; }
        private DirtyValue<string> _lenderInvestorAddress;
        /// <summary>
        /// File Contacts Addr [DENIAL.X92]
        /// </summary>
        [LoanFieldProperty(Description = "File Contacts Addr")]
        public string LenderInvestorAddress { get => _lenderInvestorAddress; set => _lenderInvestorAddress = value; }
        private DirtyValue<string> _lenderInvestorCity;
        /// <summary>
        /// File Contacts City [DENIAL.X93]
        /// </summary>
        [LoanFieldProperty(Description = "File Contacts City")]
        public string LenderInvestorCity { get => _lenderInvestorCity; set => _lenderInvestorCity = value; }
        private DirtyValue<string> _lenderInvestorName;
        /// <summary>
        /// File Contacts Co Name [DENIAL.X91]
        /// </summary>
        [LoanFieldProperty(Description = "File Contacts Co Name")]
        public string LenderInvestorName { get => _lenderInvestorName; set => _lenderInvestorName = value; }
        private DirtyValue<string> _lenderInvestorPhone;
        /// <summary>
        /// File Contacts Phone [DENIAL.X96]
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.PHONE, Description = "File Contacts Phone")]
        public string LenderInvestorPhone { get => _lenderInvestorPhone; set => _lenderInvestorPhone = value; }
        private DirtyValue<string> _lenderInvestorPostalCode;
        /// <summary>
        /// File Contacts Zip [DENIAL.X95]
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.ZIPCODE, Description = "File Contacts Zip")]
        public string LenderInvestorPostalCode { get => _lenderInvestorPostalCode; set => _lenderInvestorPostalCode = value; }
        private DirtyValue<string> _lenderInvestorState;
        /// <summary>
        /// File Contacts State [DENIAL.X94]
        /// </summary>
        [LoanFieldProperty(Format = LoanFieldFormat.STATE, Description = "File Contacts State")]
        public string LenderInvestorState { get => _lenderInvestorState; set => _lenderInvestorState = value; }
        private DirtyValue<bool?> _lengthOfEmployment;
        /// <summary>
        /// Denial Empl Status - Length [DENIAL.X43]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Empl Status - Length", OptionsJson = "{\"true\":\"Length of Employment\"}")]
        public bool? LengthOfEmployment { get => _lengthOfEmployment; set => _lengthOfEmployment = value; }
        private DirtyValue<bool?> _noCreditFile;
        /// <summary>
        /// Denial Credit - No File [DENIAL.X30]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - No File", OptionsJson = "{\"true\":\"No Credit File\"}")]
        public bool? NoCreditFile { get => _noCreditFile; set => _noCreditFile = value; }
        private DirtyValue<bool?> _numberRecentInquiriesCredit;
        /// <summary>
        /// Denial Credit - Number of Recent Inquiries on Credit Bureau Report [DENIAL.X79]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Number of Recent Inquiries on Credit Bureau Report", OptionsJson = "{\"true\":\"Number of Recent Inquiries on Credit Bureau Report\"}")]
        public bool? NumberRecentInquiriesCredit { get => _numberRecentInquiriesCredit; set => _numberRecentInquiriesCredit = value; }
        private DirtyValue<string> _otherDescription;
        /// <summary>
        /// Denial - Denied By Other Descr [DENIAL.X55]
        /// </summary>
        [LoanFieldProperty(Description = "Denial - Denied By Other Descr")]
        public string OtherDescription { get => _otherDescription; set => _otherDescription = value; }
        private DirtyValue<bool?> _poorCreditPerformance;
        /// <summary>
        /// Denial Credit - Poor Credit Performance With Us [DENIAL.X78]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Poor Credit Performance With Us", OptionsJson = "{\"true\":\"Poor Credit Performance With Us\"}")]
        public bool? PoorCreditPerformance { get => _poorCreditPerformance; set => _poorCreditPerformance = value; }
        private DirtyValue<bool?> _temporaryOrIrregularEmployment;
        /// <summary>
        /// Denial Empl Status - Temp or Irregular [DENIAL.X44]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Empl Status - Temp or Irregular", OptionsJson = "{\"true\":\"Temporary or Irregular Employment,\"}")]
        public bool? TemporaryOrIrregularEmployment { get => _temporaryOrIrregularEmployment; set => _temporaryOrIrregularEmployment = value; }
        private DirtyValue<bool?> _temporaryResidence;
        /// <summary>
        /// Denial Residency Temp [DENIAL.X47]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Residency Temp", OptionsJson = "{\"true\":\"Temporary Residence\"}")]
        public bool? TemporaryResidence { get => _temporaryResidence; set => _temporaryResidence = value; }
        private DirtyValue<bool?> _toShortPeriodOfResidence;
        /// <summary>
        /// Denial Residency Too Short [DENIAL.X48]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Residency Too Short", OptionsJson = "{\"true\":\"Too Short a Period of Residence\"}")]
        public bool? ToShortPeriodOfResidence { get => _toShortPeriodOfResidence; set => _toShortPeriodOfResidence = value; }
        private DirtyValue<bool?> _unableToVerifyCreditReferences;
        /// <summary>
        /// Denial Credit - Unable to Verify Refs [DENIAL.X33]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Unable to Verify Refs", OptionsJson = "{\"true\":\"Unable to Verify Credit References\"}")]
        public bool? UnableToVerifyCreditReferences { get => _unableToVerifyCreditReferences; set => _unableToVerifyCreditReferences = value; }
        private DirtyValue<bool?> _unableToVerifyEmployment;
        /// <summary>
        /// Denial Empl Status - Unable to Verify [DENIAL.X42]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Empl Status - Unable to Verify", OptionsJson = "{\"true\":\"Unable to Verify Employment\"}")]
        public bool? UnableToVerifyEmployment { get => _unableToVerifyEmployment; set => _unableToVerifyEmployment = value; }
        private DirtyValue<bool?> _unableToVerifyIncome;
        /// <summary>
        /// Denial Income - Unable to Verify [DENIAL.X46]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Income - Unable to Verify", OptionsJson = "{\"true\":\"Unable to Verify Income\"}")]
        public bool? UnableToVerifyIncome { get => _unableToVerifyIncome; set => _unableToVerifyIncome = value; }
        private DirtyValue<bool?> _unableToVerifyResidence;
        /// <summary>
        /// Denial Residency Unable to Verify [DENIAL.X49]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Residency Unable to Verify", OptionsJson = "{\"true\":\"Unable to Verify Residence\"}")]
        public bool? UnableToVerifyResidence { get => _unableToVerifyResidence; set => _unableToVerifyResidence = value; }
        private DirtyValue<bool?> _unacceptableAppraisal;
        /// <summary>
        /// Denial Other - Inadequate Collateral Apprais Unaccept [DENIAL.X61]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Inadequate Collateral Apprais Unaccept", OptionsJson = "{\"true\":\"Unacceptable Appraisal\"}")]
        public bool? UnacceptableAppraisal { get => _unacceptableAppraisal; set => _unacceptableAppraisal = value; }
        private DirtyValue<bool?> _unacceptableCreditReferencesProvided;
        /// <summary>
        /// Denial Credit - Unacceptable Type of Credit References Provided [DENIAL.X77]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Unacceptable Type of Credit References Provided", OptionsJson = "{\"true\":\"Unacceptable Type of Credit References Provided\"}")]
        public bool? UnacceptableCreditReferencesProvided { get => _unacceptableCreditReferencesProvided; set => _unacceptableCreditReferencesProvided = value; }
        private DirtyValue<bool?> _unacceptableLeaseholdEstate;
        /// <summary>
        /// Denial Other - Inadequate Collateral Unaccept Leasehld [DENIAL.X62]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Inadequate Collateral Unaccept Leasehld", OptionsJson = "{\"true\":\"Unacceptable Leasehold Estate\"}")]
        public bool? UnacceptableLeaseholdEstate { get => _unacceptableLeaseholdEstate; set => _unacceptableLeaseholdEstate = value; }
        private DirtyValue<bool?> _unacceptablePaymentRecordOnPreviousMtg;
        /// <summary>
        /// Denial Credit - Excess Oblig/Unaccept Pymt Record [DENIAL.X37]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Credit - Excess Oblig/Unaccept Pymt Record", OptionsJson = "{\"true\":\"Unacceptable Payment Record on\"}")]
        public bool? UnacceptablePaymentRecordOnPreviousMtg { get => _unacceptablePaymentRecordOnPreviousMtg; set => _unacceptablePaymentRecordOnPreviousMtg = value; }
        private DirtyValue<bool?> _unacceptableProperty;
        /// <summary>
        /// Denial Other - Inadequate Collateral Prpty Unaccept [DENIAL.X59]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Inadequate Collateral Prpty Unaccept", OptionsJson = "{\"true\":\"Unacceptable Property\"}")]
        public bool? UnacceptableProperty { get => _unacceptableProperty; set => _unacceptableProperty = value; }
        private DirtyValue<bool?> _weDoNotGrantCredit;
        /// <summary>
        /// Denial Other - we do not grant credit to any appl on? [DENIAL.X63]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - we do not grant credit to any appl on?", OptionsJson = "{\"true\":\"We do not grant credit to any applicant on...\"}")]
        public bool? WeDoNotGrantCredit { get => _weDoNotGrantCredit; set => _weDoNotGrantCredit = value; }
        private DirtyValue<bool?> _withdrawnByApplicant;
        /// <summary>
        /// Denial Other - Withdrawn by Applicant [DENIAL.X64]
        /// </summary>
        [LoanFieldProperty(Description = "Denial Other - Withdrawn by Applicant", OptionsJson = "{\"true\":\"Withdrawn by Applicant\"}")]
        public bool? WithdrawnByApplicant { get => _withdrawnByApplicant; set => _withdrawnByApplicant = value; }
        internal override bool DirtyInternal
        {
            get => _additionalStatement.Dirty
                || _bankruptcy.Dirty
                || _collateralNotSufficient.Dirty
                || _creditApplicationIncomplete.Dirty
                || _creditReportObtainedFromConsumerReportingAgency.Dirty
                || _delinquentCreditObligations.Dirty
                || _denialDate.Dirty
                || _denialDescription.Dirty
                || _denialMailedOn.Dirty
                || _denialOther1.Dirty
                || _denialOther2.Dirty
                || _denialOtherDesc1.Dirty
                || _denialOtherDesc2.Dirty
                || _deniedBy.Dirty
                || _deniedByFhlmc.Dirty
                || _deniedByFnma.Dirty
                || _deniedByHud.Dirty
                || _deniedByOther.Dirty
                || _deniedByVa.Dirty
                || _descriptionofAccount1.Dirty
                || _descriptionofAccount2.Dirty
                || _descriptionofAccount3.Dirty
                || _descriptionofActionTaken1.Dirty
                || _descriptionofActionTaken2.Dirty
                || _ecoaAddress.Dirty
                || _ecoaAddress2.Dirty
                || _ecoaCity.Dirty
                || _ecoaName.Dirty
                || _ecoaPhone.Dirty
                || _ecoaPostalCode.Dirty
                || _ecoaState.Dirty
                || _excessiveObligations.Dirty
                || _garnishment.Dirty
                || _id.Dirty
                || _inadequateCollateral.Dirty
                || _informationFromAConsumerReportingAgency.Dirty
                || _informationObtainedFromOutsideSource.Dirty
                || _informationObtainedInReportFromCra.Dirty
                || _insufficientCreditFile.Dirty
                || _insufficientCreditReference.Dirty
                || _insufficientData.Dirty
                || _insufficientFundsToCloseLoan.Dirty
                || _insufficientIncomeForTotalObligations.Dirty
                || _insufficientStabilityOfIncome.Dirty
                || _lackOfCashReserves.Dirty
                || _lenderInvestorAddress.Dirty
                || _lenderInvestorCity.Dirty
                || _lenderInvestorName.Dirty
                || _lenderInvestorPhone.Dirty
                || _lenderInvestorPostalCode.Dirty
                || _lenderInvestorState.Dirty
                || _lengthOfEmployment.Dirty
                || _noCreditFile.Dirty
                || _numberRecentInquiriesCredit.Dirty
                || _otherDescription.Dirty
                || _poorCreditPerformance.Dirty
                || _temporaryOrIrregularEmployment.Dirty
                || _temporaryResidence.Dirty
                || _toShortPeriodOfResidence.Dirty
                || _unableToVerifyCreditReferences.Dirty
                || _unableToVerifyEmployment.Dirty
                || _unableToVerifyIncome.Dirty
                || _unableToVerifyResidence.Dirty
                || _unacceptableAppraisal.Dirty
                || _unacceptableCreditReferencesProvided.Dirty
                || _unacceptableLeaseholdEstate.Dirty
                || _unacceptablePaymentRecordOnPreviousMtg.Dirty
                || _unacceptableProperty.Dirty
                || _weDoNotGrantCredit.Dirty
                || _withdrawnByApplicant.Dirty;
            set
            {
                _additionalStatement.Dirty = value;
                _bankruptcy.Dirty = value;
                _collateralNotSufficient.Dirty = value;
                _creditApplicationIncomplete.Dirty = value;
                _creditReportObtainedFromConsumerReportingAgency.Dirty = value;
                _delinquentCreditObligations.Dirty = value;
                _denialDate.Dirty = value;
                _denialDescription.Dirty = value;
                _denialMailedOn.Dirty = value;
                _denialOther1.Dirty = value;
                _denialOther2.Dirty = value;
                _denialOtherDesc1.Dirty = value;
                _denialOtherDesc2.Dirty = value;
                _deniedBy.Dirty = value;
                _deniedByFhlmc.Dirty = value;
                _deniedByFnma.Dirty = value;
                _deniedByHud.Dirty = value;
                _deniedByOther.Dirty = value;
                _deniedByVa.Dirty = value;
                _descriptionofAccount1.Dirty = value;
                _descriptionofAccount2.Dirty = value;
                _descriptionofAccount3.Dirty = value;
                _descriptionofActionTaken1.Dirty = value;
                _descriptionofActionTaken2.Dirty = value;
                _ecoaAddress.Dirty = value;
                _ecoaAddress2.Dirty = value;
                _ecoaCity.Dirty = value;
                _ecoaName.Dirty = value;
                _ecoaPhone.Dirty = value;
                _ecoaPostalCode.Dirty = value;
                _ecoaState.Dirty = value;
                _excessiveObligations.Dirty = value;
                _garnishment.Dirty = value;
                _id.Dirty = value;
                _inadequateCollateral.Dirty = value;
                _informationFromAConsumerReportingAgency.Dirty = value;
                _informationObtainedFromOutsideSource.Dirty = value;
                _informationObtainedInReportFromCra.Dirty = value;
                _insufficientCreditFile.Dirty = value;
                _insufficientCreditReference.Dirty = value;
                _insufficientData.Dirty = value;
                _insufficientFundsToCloseLoan.Dirty = value;
                _insufficientIncomeForTotalObligations.Dirty = value;
                _insufficientStabilityOfIncome.Dirty = value;
                _lackOfCashReserves.Dirty = value;
                _lenderInvestorAddress.Dirty = value;
                _lenderInvestorCity.Dirty = value;
                _lenderInvestorName.Dirty = value;
                _lenderInvestorPhone.Dirty = value;
                _lenderInvestorPostalCode.Dirty = value;
                _lenderInvestorState.Dirty = value;
                _lengthOfEmployment.Dirty = value;
                _noCreditFile.Dirty = value;
                _numberRecentInquiriesCredit.Dirty = value;
                _otherDescription.Dirty = value;
                _poorCreditPerformance.Dirty = value;
                _temporaryOrIrregularEmployment.Dirty = value;
                _temporaryResidence.Dirty = value;
                _toShortPeriodOfResidence.Dirty = value;
                _unableToVerifyCreditReferences.Dirty = value;
                _unableToVerifyEmployment.Dirty = value;
                _unableToVerifyIncome.Dirty = value;
                _unableToVerifyResidence.Dirty = value;
                _unacceptableAppraisal.Dirty = value;
                _unacceptableCreditReferencesProvided.Dirty = value;
                _unacceptableLeaseholdEstate.Dirty = value;
                _unacceptablePaymentRecordOnPreviousMtg.Dirty = value;
                _unacceptableProperty.Dirty = value;
                _weDoNotGrantCredit.Dirty = value;
                _withdrawnByApplicant.Dirty = value;
            }
        }
    }
}