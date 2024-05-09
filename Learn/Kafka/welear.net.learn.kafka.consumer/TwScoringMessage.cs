namespace Hci.Hcd.VnPosAppointment.InfrastructureLayer.Abstraction.Kafka;

public class TwScoringMessage
{
    public string AppointmentType { get; set; } = string.Empty;
    public string OfferId { get; set; } = string.Empty;
    public string OfferTypeCode { get; set; } = string.Empty;
    public string OfferTypeName { get; set; } = string.Empty;
    public long MaxMonthlyInst { get; set; }
    public long MaxCreditAmount { get; set; }
    public string OfferValidTo { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public string Cuid { get; set; } = string.Empty;
    public string CustomerFullName { get; set; } = string.Empty;
    public string CustomerGender { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string IdCardNr { get; set; } = string.Empty;
    public string PrimaryPhoneNumber { get; set; } = string.Empty;
    public string? PosCode { get; set; }
    public string? ReferralCode { get; set; }
    public GmaInfo GmaInfo { get; set; } = new();
    public ScoringInformation? ScoringInfo { get; set; }
}

public class ScoringInformation
{
    public string ScoringId { get; set; } = string.Empty;
    public string PartyIdentifier { get; set; } = string.Empty;
    public string ApplicantId { get; set; } = string.Empty;
    public string Salesroom { get; set; } = string.Empty;
    public string SourceChannel { get; set; } = string.Empty;
    public string ApprovedTime { get; set; } = string.Empty;
}

public class GmaInfo
{
    public bool EkycFlag { get; set; }
    public string? Note { get; set; }
}
