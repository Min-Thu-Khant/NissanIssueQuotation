using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Core
{
    public static class Messages
    {

        //Deposit Confirmation Menu 
        public static class DepositConfirmationMenu
        {
            public static string ProcessAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.DpMenuRpt_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.DpMenuRpt_w0001;
                }
            }

            public static string UserNameAndPasswordDoNotMatch
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.DpMenuInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.DpMenuInp_w0002;
                }
            }

            public static string UserNameAndPasswordEmpty
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.DpMenuInp_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.DpMenuInp_w0003;
                }
            }
        }

        public static class ConfirmationOfBankTransferInformationResult
        {
            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0001;
                }
            }

            public static string MultipleRowSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0002;
                }
            }

            public static string InvalidDateFormat
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0003;
                }
            }

            public static string RequireImportDate
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0004;
                }
            }

            public static string RequireImportDateFrom
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0005, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0005;
                }
            }
            public static string InvalidFromAndTo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0006, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0006;
                }
            }

            public static string ProcessAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiRpt_w0007, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiRpt_w0007;
                }
            }

            public static string DataWithZeroValueSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0008, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfBtiInp_w0008;
                }
            }

        }

        public static class ConfirmationOfAmigo
        {
            public static string MovedToNonAmigo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiCmp_i0001, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiCmp_i0001;
                }
            }

            public static string ProcessAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiRpt_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiRpt_w0002;
                }
            }

            public static string RoleWithZeroDataIsSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiRpt_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiRpt_w0003;
                }
            }

            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiInp_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiInp_w0004;
                }
            }

            public static string MultipleRowSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiInp_w0005, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfAmiInp_w0005;
                }
            }

        }

        public static class ConfirmationOfNonAmigo
        {
            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaInp_w0001;
                }
            }

            public static string MultipleRowSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaInp_w0002;
                }
            }

            public static string ProcessAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0003;
                }
            }

            public static string CustomerNotFound
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0004;
                }
            }

            public static string NoAllMoved
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0007, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0004;
                }
            }

            public static string MovedToAmigo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaCmp_i0005, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaCmp_i0005
;
                }
            }

            public static string RoleWithZeroDataIsSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0006, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0006;
                }
            }

            public static string CustomerNotFoundMultiCase
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0007, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfNoaRpt_w0007;
                }
            }

        }
        public static class ConfirmationOfComparisonResult
        {
            public static string InvalidDateFormat
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0001;
                }
            }
            public static string RequireDate
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0002;
                }
            }

            public static string RequireImportDateFrom
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0003;
                }
            }

            public static string InvalidDateFromAndTo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpInp_w0004;
                }
            }

            public static string ProcessAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpRpt_w0005, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfCmpRpt_w0005;
                }
            }


        }
        public static class ComparisonResultDetail
        {
            public static string InvalidDate
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0001;
                }
            }
            public static string RequireDate
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0002;
                }
            }

            public static string RequireDateFrom
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0003;
                }
            }

            public static string InvalidDateFromAndTo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0004;
                }
            }

            public static string CSVDownloaded
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlCmp_i0005, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlCmp_i0005;
                }
            }

            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0006, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlInp_w0006;
                }
            }

            public static string StatusUpdatedToCancel
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlCmp_i0007, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlCmp_i0007;
                }
            }


            public static string NoRecordToDownload
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlRpt_w0008, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.CnfDtlRpt_w0008;
                }
            }

        }

        public static class CheckUnmatchedInvoice
        {
            public static string InvalidDate
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0001;
                }
            }
            public static string RequireDate
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0002;
                }
            }

            public static string RequireDateFrom
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0003, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0003;
                }
            }

            public static string InvalidDateFromAndTo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0004;
                }
            }

            public static string ConfirmRefund
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiCnf_i0005, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiCnf_i0005;
                }
            }
            public static string StatusUpdatedToRefund
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiCmp_i0006, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiCmp_i0006;
                }
            }

            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0007, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0007;
                }
            }

            public static string MultipleRowSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0008, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ChkUmiInp_w0008;
                }
            }
        }

        public static class ResultOfDepositDatePlan
        {
            public static string MultipleRowSelected
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0016, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0016;
                }
            }

            public static string InvalidDateFromAndTo
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0012, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0012;
                }
            }

            public static string InvalidDateFormat
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0011, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0011;
                }
            }

            public static string NoSearchConditions
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0001;
                }
            }

            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0002;
                }
            }

            public static string CannotbeManuallyAllocated
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_i0013, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_i0013;
                }
            }

            public static string CannotBeAllocated
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_i0014, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_i0014;
                }
            }

            public static string CannotBeCanceled
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_i0015, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_i0015;
                }
            }

            public static string RecordUpdated
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepCmp_i0003, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepCmp_i0003;
                }
            }

            public static string ExcelDownloaded
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepCmp_i0004, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepCmp_i0004;
                }
            }

            public static string RequireOnlyOneYearAndMonth
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0005, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0005;
                }
            }
            public static string RequireOneYearAndMonth
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0006, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0006;
                }
            }
            
            public static string YearMonthFormat
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0008, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepInp_w0008;
                }
            }


            public static string NoRecordToDownload
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_w0009, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_w0009;
                }
            }

            public static string InvalidGridData
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_w0010, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.RstDepRpt_w0010;
                }
            }

        }
        public static class UpdateCUSTOMER_MASTER
        {
            public static string NoSearchConditions
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumInp_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumInp_w0001;
                }
            }

            public static string NoSelectedRow
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumInp_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumInp_w0002;
                }
            }

            public static string RecordUpdated
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumCmp_i0003, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumCmp_i0003;
                }
            }

            public static string ProcessAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumRpt_w0004, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumRpt_w0004;
                }
            }

            public static string InvalidGridData
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumRpt_w0005, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumRpt_w0005;
                }
            }

            public static string BankAccountNotUnique
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumRpt_w0006, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.UpdCumRpt_w0006;
                }
            }

        }

        public static class ImportBankDepositData
        {
            public static string NoImportFileFound
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ImpDepRpt_w0001, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ImpDepRpt_w0001;
                }
            }

            public static string FileIsNotMoved
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ImpDepRpt_w0002, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ImpDepRpt_w0002;
                }
            }

            public static string ImportSuccess
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ImpDepCmp_i0003, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.ImpDepCmp_i0003;
                }
            }

        }

        public static class MatchToInvoice
        {
            public static string MatchingSuccess
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.MtcInvCmp_i0003, Utility.LogType.Info);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.MtcInvCmp_i0003;
                }
            }
        }

        public static class General
        {
            public static string ServerTimeOut
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0002, Utility.LogType.Error);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0002;
                }
            }

            public static string NoConnection
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0003, Utility.LogType.Error);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0003;
                }
            }

            public static string NoProgramFound
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0004, Utility.LogType.Error);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0004;
                }
            }

            public static string ThereWasAnError
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0001, Utility.LogType.Error);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_s0001;
                }
            }
            
            public static string ProgramIsAlreadyRunning
            {
                get
                {
                    //log message
                    Utility.WriteActivityLog(AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_i0005, Utility.LogType.Warn);
                    //return message
                    return AmigoPapaerWorkProcessSystem.Core.Properties.Resources.GnmsgRpt_i0005;
                }
            }
        }
    }
}
