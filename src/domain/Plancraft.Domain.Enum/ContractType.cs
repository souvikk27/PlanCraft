namespace Plancraft.Domain.Enum;

public enum ContractType
{
    FixedPrice = 0,
    TimeAndMaterial = 1,
    CostPlus = 2,
    UnitPrice = 3,
    LumpSum = 4,
    IncentiveBased = 5,
    CostReimbursable = 6,
    JointVenture = 7,
    BuildOperateTransfer = 8,
    ServiceLevelAgreement = 9
}

public static class ProjectContractTypeExtensions
{
    public static string ToDescriptionString(this ContractType contractType)
    {
        switch (contractType)
        {
            case ContractType.FixedPrice:
                return "Fixed Price Contract";
            case ContractType.TimeAndMaterial:
                return "Time and Material Contract";
            case ContractType.CostPlus:
                return "Cost Plus Contract";
            case ContractType.UnitPrice:
                return "Unit Price Contract";
            case ContractType.LumpSum:
                return "Lump Sum Contract";
            case ContractType.IncentiveBased:
                return "Incentive-Based Contract";
            case ContractType.CostReimbursable:
                return "Cost Reimbursable Contract";
            case ContractType.JointVenture:
                return "Joint Venture Contract";
            case ContractType.BuildOperateTransfer:
                return "Build-Operate-Transfer (BOT) Contract";
            case ContractType.ServiceLevelAgreement:
                return "Service Level Agreement (SLA)";
            default:
                return contractType.ToString();
        }
    }
}