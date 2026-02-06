using Plugin.Maui.Barkoder.Enums;

namespace BarkoderMaui.Utils;

public static class BarcodeTypeMapper
{
    private static readonly Dictionary<string, BarcodeType> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["australianPost"] = BarcodeType.AustralianPost,
        ["codabar"] = BarcodeType.Codabar,
        ["code11"] = BarcodeType.Code11,
        ["code128"] = BarcodeType.Code128,
        ["code25"] = BarcodeType.Code25,
        ["code32"] = BarcodeType.Code32,
        ["code39"] = BarcodeType.Code39,
        ["code93"] = BarcodeType.Code93,
        ["coop25"] = BarcodeType.Coop25,
        ["datalogic25"] = BarcodeType.Datalogic25,
        ["databar14"] = BarcodeType.Databar14,
        ["databarExpanded"] = BarcodeType.DatabarExpanded,
        ["databarLimited"] = BarcodeType.DatabarLimited,
        ["ean13"] = BarcodeType.Ean13,
        ["ean8"] = BarcodeType.Ean8,
        ["iata25"] = BarcodeType.Uata25,
        ["interleaved25"] = BarcodeType.Interleaved25,
        ["itf14"] = BarcodeType.Itf14,
        ["japanesePost"] = BarcodeType.JapanesePost,
        ["kix"] = BarcodeType.KIX,
        ["matrix25"] = BarcodeType.Matrix25,
        ["msi"] = BarcodeType.Msi,
        ["planet"] = BarcodeType.Planet,
        ["postalIMB"] = BarcodeType.PostalIMB,
        ["postnet"] = BarcodeType.Postnet,
        ["royalMail"] = BarcodeType.RoyalMail,
        ["telepen"] = BarcodeType.Telepen,
        ["upcA"] = BarcodeType.UpcA,
        ["upcE"] = BarcodeType.UpcE,
        ["upcE1"] = BarcodeType.UpcE1,

        ["aztec"] = BarcodeType.Aztec,
        ["aztecCompact"] = BarcodeType.AztecCompact,
        ["datamatrix"] = BarcodeType.Datamatrix,
        ["dotcode"] = BarcodeType.Dotcode,
        ["idDocument"] = BarcodeType.IDDocument,
        ["maxiCode"] = BarcodeType.Maxicode,
        ["ocrText"] = BarcodeType.OCRText,
        ["pdf417"] = BarcodeType.PDF417,
        ["pdf417Micro"] = BarcodeType.PDF417Micro,
        ["qr"] = BarcodeType.QR,
        ["qrMicro"] = BarcodeType.QRMicro,
    };

    public static bool TryGet(string id, out BarcodeType type)
        => Map.TryGetValue(id, out type);
}

