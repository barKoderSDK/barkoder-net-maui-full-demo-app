using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.ExifInterface.Media;
using Barkoder;
using Com.Barkoder;
using Com.Barkoder.Enums;
using Com.Barkoder.Interfaces;
using Com.Barkoder.Overlaymanager;
using Java.Interop;
using Java.Lang;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Newtonsoft.Json;
using Org.Json;
using Plugin.Maui.Barkoder.Enums;
using Plugin.Maui.Barkoder.Handlers;
using Plugin.Maui.Barkoder.Interfaces;
using _Microsoft.Android.Resource.Designer;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]
[assembly: AssemblyCompany("Barkoder")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright @2023 Barkoder")]
[assembly: AssemblyDescription("The barKoder SDK Maui plugin grants an easy to use Maui solution with a great interface that can be integrated in both iOS and Android apps. Integrating the barKoder Barcode Scanner SDK into your Enterprise or Consumer-facing mobile apps will instantly transform your user's smartphones and tablets into rugged barcode scanning devices without the need to procure and maintain expensive and sluggish hardware devices that have a very short life span.")]
[assembly: AssemblyFileVersion("1.6.7.0")]
[assembly: AssemblyInformationalVersion("1.6.7+a51f96ffaa80e569a259609a0b586afdf0893b6d")]
[assembly: AssemblyProduct("Plugin.Maui.Barkoder")]
[assembly: AssemblyTitle("Plugin.Maui.Barkoder")]
[assembly: TargetPlatform("Android34.0")]
[assembly: SupportedOSPlatform("Android21.0")]
[assembly: AssemblyVersion("1.6.7.0")]
[module: RefSafetyRules(11)]
namespace Barkoder
{
	public class BarkoderConfig
	{
		public long locationLineColor;

		public int locationLineWidth;

		public long roiLineColor;

		public int roiLineWidth;

		public long roiOverlayBackgroundColor;

		public bool closeSessionOnResultEnabled;

		public bool imageResultEnabled;

		public bool locationInImageResultEnabled;

		public bool locationInPreviewEnabled;

		public bool pinchToZoomEnabled;

		public bool regionOfInterestVisible;

		public bool beepOnSuccessEnabled;

		public bool vibrateOnSuccessEnabled;

		public DekoderConfig decoder;

		public BarkoderConfig(long? locationLineColor = null, int? locationLineWidth = null, long? roiLineColor = null, int? roiLineWidth = null, long? roiOverlayBackgroundColor = null, bool? closeSessionOnResultEnabled = null, bool? imageResultEnabled = null, bool? locationInImageResultEnabled = null, bool? locationInPreviewEnabled = null, bool? pinchToZoomEnabled = null, bool? regionOfInterestVisible = null, bool? beepOnSuccessEnabled = null, bool? vibrateOnSuccessEnabled = null, DekoderConfig? decoder = null)
		{
			this.locationLineColor = locationLineColor ?? 4291559705u;
			this.locationLineWidth = locationLineWidth ?? 2;
			this.roiLineColor = roiLineColor ?? 4291559705u;
			this.roiLineWidth = roiLineWidth ?? 2;
			this.roiOverlayBackgroundColor = roiOverlayBackgroundColor ?? 4291559705u;
			this.closeSessionOnResultEnabled = closeSessionOnResultEnabled ?? true;
			this.imageResultEnabled = imageResultEnabled ?? true;
			this.locationInImageResultEnabled = locationInImageResultEnabled ?? true;
			this.locationInPreviewEnabled = locationInPreviewEnabled ?? true;
			this.pinchToZoomEnabled = pinchToZoomEnabled == true;
			this.regionOfInterestVisible = regionOfInterestVisible ?? true;
			this.beepOnSuccessEnabled = beepOnSuccessEnabled ?? true;
			this.vibrateOnSuccessEnabled = vibrateOnSuccessEnabled ?? true;
			this.decoder = decoder ?? new DekoderConfig();
		}
	}
	public class DekoderConfig
	{
		[JsonProperty("Aztec")]
		public BarcodeConfig aztec;

		[JsonProperty("Aztec Compact")]
		public BarcodeConfig aztecCompact;

		[JsonProperty("QR")]
		public DatamatrixBarcodeConfig qr;

		[JsonProperty("QR Micro")]
		public DatamatrixBarcodeConfig qrMicro;

		[JsonProperty("Code 128")]
		public BarcodeConfigWithLength code128;

		[JsonProperty("Code 93")]
		public BarcodeConfigWithLength code93;

		[JsonProperty("Code 39")]
		public Code39BarcodeConfig code39;

		[JsonProperty("Codabar")]
		public BarcodeConfigWithLength codabar;

		[JsonProperty("Code 11")]
		public Code11BarcodeConfig code11;

		[JsonProperty("MSI")]
		public MSIBarcodeConfig msi;

		[JsonProperty("Upc-A")]
		public BarcodeConfig upcA;

		[JsonProperty("Upc-E")]
		public BarcodeConfig upcE;

		[JsonProperty("Upc-E1")]
		public BarcodeConfig upcE1;

		[JsonProperty("Ean-13")]
		public BarcodeConfig ean13;

		[JsonProperty("Ean-8")]
		public BarcodeConfig ean8;

		[JsonProperty("PDF 417")]
		public BarcodeConfig pdf417;

		[JsonProperty("PDF 417 Micro")]
		public BarcodeConfig pdf417Micro;

		[JsonProperty("Datamatrix")]
		public DatamatrixBarcodeConfig datamatrix;

		[JsonProperty("Code 25")]
		public BarcodeConfig code25;

		[JsonProperty("Interleaved 2 of 5")]
		public BarcodeConfig interleaved25;

		[JsonProperty("ITF 14")]
		public BarcodeConfig itf14;

		[JsonProperty("IATA 25")]
		public BarcodeConfig iata25;

		[JsonProperty("Matrix 25")]
		public BarcodeConfig matrix25;

		[JsonProperty("Datalogic 25")]
		public BarcodeConfig datalogic25;

		[JsonProperty("COOP 25")]
		public BarcodeConfig coop25;

		[JsonProperty("Code 32")]
		public BarcodeConfig code32;

		[JsonProperty("Telepen")]
		public BarcodeConfig telepen;

		[JsonProperty("Dotcode")]
		public BarcodeConfig dotcode;

		[JsonProperty("ID Document")]
		public BarcodeConfig idDocument;

		[JsonProperty("Databar 14")]
		public BarcodeConfig databar14;

		[JsonProperty("Databar Limited")]
		public BarcodeConfig databarLimited;

		[JsonProperty("Databar Expanded")]
		public BarcodeConfig databarExpanded;

		[JsonProperty("Postal IMB")]
		public BarcodeConfig postalIMB;

		[JsonProperty("Postnet")]
		public BarcodeConfig postnet;

		[JsonProperty("Planet")]
		public BarcodeConfig planet;

		[JsonProperty("Australian Post")]
		public BarcodeConfig australianPost;

		[JsonProperty("Royal Mail")]
		public BarcodeConfig royalMail;

		[JsonProperty("KIX")]
		public BarcodeConfig kix;

		[JsonProperty("Japanese Post")]
		public BarcodeConfig japanesePost;

		[JsonProperty("MaxiCode")]
		public BarcodeConfig maxicode;

		[JsonProperty("OCR Text")]
		public BarcodeConfig ocrText;

		[JsonProperty("general")]
		public GeneralSettings general;

		public DekoderConfig(BarcodeConfig? aztec = null, BarcodeConfig? aztecCompact = null, DatamatrixBarcodeConfig? qr = null, DatamatrixBarcodeConfig? qrMicro = null, BarcodeConfigWithLength? code128 = null, BarcodeConfigWithLength? code93 = null, Code39BarcodeConfig? code39 = null, BarcodeConfigWithLength? codabar = null, Code11BarcodeConfig? code11 = null, MSIBarcodeConfig? msi = null, BarcodeConfig? upcA = null, BarcodeConfig? upcE = null, BarcodeConfig? upcE1 = null, BarcodeConfig? ean13 = null, BarcodeConfig? ean8 = null, BarcodeConfig? pdf417 = null, BarcodeConfig? pdf417Micro = null, DatamatrixBarcodeConfig? datamatrix = null, BarcodeConfig? code25 = null, BarcodeConfig? interleaved25 = null, BarcodeConfig? itf14 = null, BarcodeConfig? iata25 = null, BarcodeConfig? matrix25 = null, BarcodeConfig? datalogic25 = null, BarcodeConfig? coop25 = null, BarcodeConfig? code32 = null, BarcodeConfig? telepen = null, BarcodeConfig? dotcode = null, BarcodeConfig? maxicode = null, BarcodeConfig? idDocument = null, BarcodeConfig? databar14 = null, BarcodeConfig? databarLimited = null, BarcodeConfig? databarExpanded = null, BarcodeConfig? postalIMB = null, BarcodeConfig? postnet = null, BarcodeConfig? planet = null, BarcodeConfig? australianPost = null, BarcodeConfig? royalMail = null, BarcodeConfig? kix = null, BarcodeConfig? japanesePost = null, BarcodeConfig? ocrText = null, GeneralSettings? general = null)
		{
			this.aztec = aztec ?? new BarcodeConfig();
			this.aztecCompact = aztecCompact ?? new BarcodeConfig();
			this.qr = qr ?? new DatamatrixBarcodeConfig();
			this.qrMicro = qrMicro ?? new DatamatrixBarcodeConfig();
			this.code128 = code128 ?? new BarcodeConfigWithLength();
			this.code93 = code93 ?? new BarcodeConfigWithLength();
			this.code39 = code39 ?? new Code39BarcodeConfig();
			this.codabar = codabar ?? new BarcodeConfigWithLength();
			this.code11 = code11 ?? new Code11BarcodeConfig();
			this.msi = msi ?? new MSIBarcodeConfig();
			this.upcA = upcA ?? new BarcodeConfig();
			this.upcE = upcE ?? new BarcodeConfig();
			this.upcE1 = upcE1 ?? new BarcodeConfig();
			this.ean13 = ean13 ?? new BarcodeConfig();
			this.ean8 = ean8 ?? new BarcodeConfig();
			this.pdf417 = pdf417 ?? new BarcodeConfig();
			this.pdf417Micro = pdf417Micro ?? new BarcodeConfig();
			this.datamatrix = datamatrix ?? new DatamatrixBarcodeConfig();
			this.code25 = code25 ?? new BarcodeConfig();
			this.interleaved25 = interleaved25 ?? new BarcodeConfig();
			this.itf14 = itf14 ?? new BarcodeConfig();
			this.iata25 = iata25 ?? new BarcodeConfig();
			this.matrix25 = matrix25 ?? new BarcodeConfig();
			this.datalogic25 = datalogic25 ?? new BarcodeConfig();
			this.coop25 = coop25 ?? new BarcodeConfig();
			this.code32 = code32 ?? new BarcodeConfig();
			this.telepen = telepen ?? new BarcodeConfig();
			this.dotcode = dotcode ?? new BarcodeConfig();
			this.maxicode = maxicode ?? new BarcodeConfig();
			this.idDocument = idDocument ?? new BarcodeConfig();
			this.databar14 = databar14 ?? new BarcodeConfig();
			this.databarLimited = databarLimited ?? new BarcodeConfig();
			this.databarExpanded = databarExpanded ?? new BarcodeConfig();
			this.postalIMB = postalIMB ?? new BarcodeConfig();
			this.postnet = postnet ?? new BarcodeConfig();
			this.planet = planet ?? new BarcodeConfig();
			this.australianPost = australianPost ?? new BarcodeConfig();
			this.royalMail = royalMail ?? new BarcodeConfig();
			this.kix = kix ?? new BarcodeConfig();
			this.japanesePost = japanesePost ?? new BarcodeConfig();
			this.ocrText = ocrText ?? new BarcodeConfig();
			this.general = general ?? new GeneralSettings();
		}
	}
	public class GeneralSettings
	{
		[JsonProperty("maxThreads")]
		public int ThreadsLimit;

		[JsonProperty("decodingSpeed")]
		public DecodingSpeed DecodingSpeed;

		[JsonProperty("roi_x")]
		public int RoiX;

		[JsonProperty("roi_y")]
		public int RoiY;

		[JsonProperty("roi_w")]
		public int RoiWidth;

		[JsonProperty("roi_h")]
		public int RoiHeight;

		[JsonProperty("formattingType")]
		public FormattingType FormattingType;

		[JsonProperty("encodingCharacterSet")]
		public string EncodingCharacterSet;

		[JsonProperty("upcEanDeblur")]
		public bool UpcEanDeblur;

		[JsonProperty("enableMisshaped1D")]
		public bool EnableMisshaped1D;

		public GeneralSettings(int? threadsLimit = null, DecodingSpeed? decodingSpeed = null, int? roiX = null, int? roiY = null, int? roiWidth = null, int? roiHeight = null, FormattingType? formattingType = null, string? encodingCharacterSet = null, bool? upcEanDeblur = null, bool? enableMisshaped1D = null)
		{
			ThreadsLimit = threadsLimit ?? 2;
			DecodingSpeed = decodingSpeed ?? DecodingSpeed.Normal;
			RoiX = roiX ?? 5;
			RoiY = roiY ?? 5;
			RoiWidth = roiWidth ?? 90;
			RoiHeight = roiHeight ?? 90;
			FormattingType = formattingType.GetValueOrDefault();
			EncodingCharacterSet = encodingCharacterSet ?? "";
			UpcEanDeblur = upcEanDeblur == true;
			EnableMisshaped1D = enableMisshaped1D == true;
		}
	}
	public class BarcodeConfig
	{
		public bool enabled;

		public BarcodeConfig(bool? enabled = null)
		{
			this.enabled = enabled == true;
		}
	}
	public class BarcodeConfigWithLength : BarcodeConfig
	{
		public int minLength;

		public int maxLength;

		public BarcodeConfigWithLength(bool? enabled = null, int? minLength = null, int? maxLenght = null)
		{
			base.enabled = enabled == true;
			maxLength = maxLenght.GetValueOrDefault();
			this.minLength = minLength.GetValueOrDefault();
		}
	}
	public class Code39BarcodeConfig : BarcodeConfigWithLength
	{
		public Code39ChecksumType checksum;

		public Code39BarcodeConfig(bool? enabled = null, int? minLength = null, int? maxLenght = null, Code39ChecksumType? checksum = null)
		{
			base.enabled = enabled == true;
			maxLength = maxLenght.GetValueOrDefault();
			base.minLength = minLength.GetValueOrDefault();
			this.checksum = checksum.GetValueOrDefault();
		}
	}
	public class Code11BarcodeConfig : BarcodeConfigWithLength
	{
		public Code11ChecksumType checksum;

		public Code11BarcodeConfig(bool? enabled = null, int? minLength = null, int? maxLenght = null, Code11ChecksumType? checksum = null)
		{
			base.enabled = enabled == true;
			maxLength = maxLenght.GetValueOrDefault();
			base.minLength = minLength.GetValueOrDefault();
			this.checksum = checksum.GetValueOrDefault();
		}
	}
	public class MSIBarcodeConfig : BarcodeConfigWithLength
	{
		public MsiChecksumType checksum;

		public MSIBarcodeConfig(bool? enabled = null, int? minLength = null, int? maxLenght = null, MsiChecksumType? checksum = null)
		{
			base.enabled = enabled == true;
			maxLength = maxLenght.GetValueOrDefault();
			base.minLength = minLength.GetValueOrDefault();
			this.checksum = checksum.GetValueOrDefault();
		}
	}
	public class DatamatrixBarcodeConfig : BarcodeConfigWithLength
	{
		private int dpmMode;

		public DatamatrixBarcodeConfig(bool? enabled = null, int? minLength = null, int? maxLenght = null, int? dpmMode = null)
		{
			base.enabled = enabled == true;
			maxLength = maxLenght.GetValueOrDefault();
			base.minLength = minLength.GetValueOrDefault();
			this.dpmMode = dpmMode.GetValueOrDefault();
		}
	}
}
namespace Plugin.Maui.Barkoder
{
	public class Resource : Resource
	{
	}
}
namespace Plugin.Maui.Barkoder.Controls
{
	public static class ViewReadyExtensions
	{
		public static Task WhenLoadedAsync(this VisualElement v, CancellationToken ct = default(CancellationToken))
		{
			if (v.IsLoaded)
			{
				return Task.CompletedTask;
			}
			TaskCompletionSource tcs = new TaskCompletionSource();
			EventHandler handler = null;
			handler = delegate
			{
				v.Loaded -= handler;
				tcs.TrySetResult();
			};
			v.Loaded += handler;
			if (ct.CanBeCanceled)
			{
				ct.Register(delegate
				{
					v.Loaded -= handler;
					tcs.TrySetCanceled(ct);
				});
			}
			return tcs.Task;
		}

		public static Task WhenHandlerReadyAsync(this VisualElement v, CancellationToken ct = default(CancellationToken))
		{
			if (v.Handler != null)
			{
				return Task.CompletedTask;
			}
			TaskCompletionSource tcs = new TaskCompletionSource();
			EventHandler handler = null;
			handler = delegate
			{
				if (v.Handler != null)
				{
					((Element)v).HandlerChanged -= handler;
					tcs.TrySetResult();
				}
			};
			((Element)v).HandlerChanged += handler;
			if (ct.CanBeCanceled)
			{
				ct.Register(delegate
				{
					((Element)v).HandlerChanged -= handler;
					tcs.TrySetCanceled(ct);
				});
			}
			return tcs.Task;
		}

		public static Task WhenSizedAsync(this VisualElement v, CancellationToken ct = default(CancellationToken))
		{
			if (v.Width > 0.0 && v.Height > 0.0 && v.IsLoaded)
			{
				return Task.CompletedTask;
			}
			TaskCompletionSource tcs = new TaskCompletionSource();
			EventHandler handler = null;
			handler = delegate
			{
				if (v.IsLoaded && !(v.Width <= 0.0) && !(v.Height <= 0.0))
				{
					v.SizeChanged -= handler;
					tcs.TrySetResult();
				}
			};
			v.SizeChanged += handler;
			if (ct.CanBeCanceled)
			{
				ct.Register(delegate
				{
					v.SizeChanged -= handler;
					tcs.TrySetCanceled(ct);
				});
			}
			return tcs.Task;
		}

		/// <summary> 
		/// "Ready" for controls that need the native view + a real size. 
		/// </summary> 
		public static async Task whenScannerReady(this VisualElement v, CancellationToken ct = default(CancellationToken))
		{
			await v.WhenLoadedAsync(ct);
			await v.WhenHandlerReadyAsync(ct);
			await v.WhenSizedAsync(ct);
		}
	}
	public class BarkoderView : View
	{
		private List<BarcodeTypeEventArgs> BarcodeTypes;

		public static BindableProperty RegionOfInterestVisibleProperty = BindableProperty.Create("RegionOfInterestVisible", typeof(bool), typeof(BarkoderView), (object)true, (BindingMode)1, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty LicenseKeyProperty = BindableProperty.Create("LicenseKey", typeof(string), typeof(BarkoderView), (object)"Default_License_key", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty VersionProperty = BindableProperty.Create("Version", typeof(string), typeof(BarkoderView), (object)"1.0", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty LibVersionProperty = BindableProperty.Create("LibVersion", typeof(string), typeof(BarkoderView), (object)"1.0", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty IsFlashAvailableProperty = BindableProperty.Create("RegionOfInterestVisible", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty MaxZoomFactorProperty = BindableProperty.Create("MaxZoomFactor", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty LocationLineColorHexProperty = BindableProperty.Create("LocationLineColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARNonSelectedLocationLineColorHexProperty = BindableProperty.Create("ARNonSelectedLocationLineColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARSelectedLocationLineColorHexProperty = BindableProperty.Create("ARSelectedLocationLineColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARSelectedHeaderTextColorHexProperty = BindableProperty.Create("ARSelectedHeaderTextColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARNonSelectedHeaderTextColorHexProperty = BindableProperty.Create("ARNonSelectedHeaderTextColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty RoiLineColorHexProperty = BindableProperty.Create("RoiLineColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ScanningIndicatorColorHexProperty = BindableProperty.Create("ScanningIndicatorLineColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty RoiOverlayBackgroundColorHexProperty = BindableProperty.Create("RoiOverlayBackgroundColorHex", typeof(string), typeof(BarkoderView), (object)"#000000", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty EncodingCharacterSetProperty = BindableProperty.Create("EncodingCharacterSet", typeof(string), typeof(BarkoderView), (object)"N/A", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARHeaderTextFormatProperty = BindableProperty.Create("ARHeaderTextFormat", typeof(string), typeof(BarkoderView), (object)"N/A", (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty LocationLineWidthProperty = BindableProperty.Create("LocationLineWidth", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARSelectedLocationLineWidthProperty = BindableProperty.Create("ARSelectedLocationLineWidth", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARNonSelectedLocationLineWidthProperty = BindableProperty.Create("ARNonSelectedLocationLineWidth", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARLocationTransitionSpeedProperty = BindableProperty.Create("ARLocationTransitionSpeed", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ScanningIndicatorLineWidthProperty = BindableProperty.Create("ScanningIndicatorLineWidth", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty RoiLineWidthProperty = BindableProperty.Create("RoiLineWidth", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ImageResultEnabledProperty = BindableProperty.Create("ImageResultEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARImageResultEnabledProperty = BindableProperty.Create("ARImageResultEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty LocationInImageResultEnabledProperty = BindableProperty.Create("LocationInImageResultEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty LocationInPreviewEnabledProperty = BindableProperty.Create("LocationInPreviewEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty PinchToZoomEnabledProperty = BindableProperty.Create("PinchToZoomEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BeepOnSuccessEnabledProperty = BindableProperty.Create("BeepOnSuccessEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ScanningIndicatorAlwaysVisibleProperty = BindableProperty.Create("ScanningIndicatorAlwaysVisibleEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty VibrateOnSuccessEnabledProperty = BindableProperty.Create("VibrateOnSuccessEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty CloseSessionOnResultEnabledProperty = BindableProperty.Create("CloseSessionOnResultEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARContinueScanningOnLimitProperty = BindableProperty.Create("ARContinueScanningOnLimit", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty AREmitResultsAtSessionEndOnlyProperty = BindableProperty.Create("AREmitResultsAtSessionEndOnly", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BarkoderResolutionProperty = BindableProperty.Create("BarkoderResolution", typeof(Plugin.Maui.Barkoder.Enums.BarkoderResolution), typeof(BarkoderView), (object)Plugin.Maui.Barkoder.Enums.BarkoderResolution.HD, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BarkoderARModeProperty = BindableProperty.Create("BarkoderARMode", typeof(Plugin.Maui.Barkoder.Enums.BarkoderARMode), typeof(BarkoderView), (object)Plugin.Maui.Barkoder.Enums.BarkoderARMode.OFF, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BarkoderARHeaderShowModeProperty = BindableProperty.Create("BarkoderARHeaderShowMode", typeof(Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode), typeof(BarkoderView), (object)Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.ONSELECTED, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BarkoderARLocationTypeProperty = BindableProperty.Create("BarkoderARLocationType", typeof(Plugin.Maui.Barkoder.Enums.BarkoderARLocationType), typeof(BarkoderView), (object)Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.TIGHT, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BarkoderARoverlayRefreshProperty = BindableProperty.Create("BarkoderAROverlayRefresh", typeof(Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh), typeof(BarkoderView), (object)Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh.NORMAL, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty DecodingSpeedProperty = BindableProperty.Create("DecodingSpeed", typeof(DecodingSpeed), typeof(BarkoderView), (object)DecodingSpeed.Normal, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty FormattingTypeProperty = BindableProperty.Create("FormattingType", typeof(FormattingType), typeof(BarkoderView), (object)FormattingType.Automatic, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty MsiChecksumTypeProperty = BindableProperty.Create("MsiChecksumType", typeof(MsiChecksumType), typeof(BarkoderView), (object)MsiChecksumType.Mod10, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty Code11ChecksumTypeProperty = BindableProperty.Create("Code11ChecksumType", typeof(Code11ChecksumType), typeof(BarkoderView), (object)Code11ChecksumType.Disabled, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty Code39ChecksumTypeProperty = BindableProperty.Create("Code39ChecksumType", typeof(Code39ChecksumType), typeof(BarkoderView), (object)Code39ChecksumType.Disabled, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty IdDocumentMasterChecksumEnabledProperty = BindableProperty.Create("IdDocumentMasterCheckSumEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty DatamatrixDpmModeEnabledProperty = BindableProperty.Create("DatamatrixDpmModeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty QRDpmModeEnabledProperty = BindableProperty.Create("QRDpmModeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty QRMicroDpmModeEnabledProperty = BindableProperty.Create("QRMIcroDpmModeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty UpcEanDeblurEnabledProperty = BindableProperty.Create("UpcEanDeblurEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty EnableMisshaped1DEnabledProperty = BindableProperty.Create("EnableMisshaped1DEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty BarcodeThumbnailOnResultEnabledProperty = BindableProperty.Create("BarcodeThumbnailOnResultEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARBarcodeThumbnailOnResultEnabledProperty = BindableProperty.Create("ARBarcodeThumbnailOnResultEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty MaximumResultsCountProperty = BindableProperty.Create("MaximumResultsCount", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARResultLimitProperty = BindableProperty.Create("ARResultLimit", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ResultDisappearanceDelayMsProperty = BindableProperty.Create("ResultDisappearanceDelayMs", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty HeaderARVerticalTextMarginProperty = BindableProperty.Create("HeaderARVerticalTextMargin", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty HeaderARHorizontalTextMarginProperty = BindableProperty.Create("HeaderARHorizontalTextMargin", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARHeaderHeightProperty = BindableProperty.Create("ARHeaderHeight", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARHeaderMaxTextHeightProperty = BindableProperty.Create("ARHeaderMaxTextHeight", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARHeaderMinTextHeightProperty = BindableProperty.Create("ARHeaderMinTextHeight", typeof(double), typeof(BarkoderView), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ScanningIndicatorAnimationModeProperty = BindableProperty.Create("ScanningIndicatorAnimationMode", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty DuplicatesDelayMsProperty = BindableProperty.Create("DuplicatesDelayMs", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty VINRestrictionsEnabledProperty = BindableProperty.Create("VINRestrictionsEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ARDoubleTapToFreezeEnabledProperty = BindableProperty.Create("ARDoubleTapToFreezeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty ThresholdBetweenDuplicatesScansProperty = BindableProperty.Create("ThresholdBetweenDuplicatesScans", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty EnableCompositeProperty = BindableProperty.Create("EnableComposite", typeof(int), typeof(BarkoderView), (object)0, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static BindableProperty RegionOfInterestProperty = BindableProperty.Create("RegionOfInterest", typeof((int, int, int, int)), typeof(BarkoderView), (object)(0, 0, 0, 0), (BindingMode)1, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static readonly BindableProperty IsIdDocumentMasterChecksumEnabledProperty = BindableProperty.Create("IsIdDocumentMasterChecksumEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static readonly BindableProperty IsDatamatrixDpmModeEnabledProperty = BindableProperty.Create("IsDatamatrixDpmModeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static readonly BindableProperty IsQRDpmModeEnabledProperty = BindableProperty.Create("IsQRDpmModeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		public static readonly BindableProperty IsQRMicroDpmModeEnabledProperty = BindableProperty.Create("IsQRMicroDpmModeEnabled", typeof(bool), typeof(BarkoderView), (object)false, (BindingMode)2, (ValidateValueDelegate)null, (BindingPropertyChangedDelegate)null, (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

		/// <summary>
		/// Retrieves the version of the Barkoder library.
		/// </summary>
		public string Version
		{
			get
			{
				return (string)((BindableObject)this).GetValue(VersionProperty);
			}
			set
			{
				((BindableObject)this).SetValue(VersionProperty, (object)value);
			}
		}

		public string LibVersion
		{
			get
			{
				return (string)((BindableObject)this).GetValue(LibVersionProperty);
			}
			set
			{
				((BindableObject)this).SetValue(LibVersionProperty, (object)value);
			}
		}

		public string LicenseKey
		{
			get
			{
				return (string)((BindableObject)this).GetValue(LicenseKeyProperty);
			}
			set
			{
				((BindableObject)this).SetValue(LicenseKeyProperty, (object)value);
			}
		}

		/// <summary>
		/// Checks or sets if the region of interest (ROI) is visible.
		/// </summary>
		public bool RegionOfInterestVisible
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(RegionOfInterestVisibleProperty);
			}
			set
			{
				((BindableObject)this).SetValue(RegionOfInterestVisibleProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetRegionOfInterestVisibleRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks whether the device has a built-in flash (torch) that can be used for illumination during barcode scanning.
		/// </summary>
		public bool IsFlashAvailable
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(IsFlashAvailableProperty);
			}
			set
			{
				((BindableObject)this).SetValue(IsFlashAvailableProperty, (object)value);
			}
		}

		/// <summary>
		/// Retrieves or sets the maximum available zoom factor for the device's camera.
		/// </summary>
		public double MaxZoomFactor
		{
			get
			{
				return (double)((BindableObject)this).GetValue(MaxZoomFactorProperty);
			}
			set
			{
				((BindableObject)this).SetValue(MaxZoomFactorProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetZoomFactorRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the hexadecimal color code representing the line color used to indicate the location of detected barcodes.
		/// </summary>
		public string LocationLineColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(LocationLineColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(LocationLineColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetLocationLineColorRequested", (object)value);
				}
			}
		}

		public string ARNonSelectedLocationLineColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(ARNonSelectedLocationLineColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARNonSelectedLocationLineColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARNonSelectedLocationLineColorRequested", (object)value);
				}
			}
		}

		public string ARSelectedLocationLineColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(ARSelectedLocationLineColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARSelectedLocationLineColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARSelectedLocationLineColorRequested", (object)value);
				}
			}
		}

		public string ARSelectedHeaderTextColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(ARSelectedHeaderTextColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARSelectedHeaderTextColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARSelectedHeaderTextColorRequested", (object)value);
				}
			}
		}

		public string ARNonSelectedHeaderTextColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(ARNonSelectedHeaderTextColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARNonSelectedHeaderTextColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARNonSelectedHeaderTextColorRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the hexadecimal color code representing the line color of the Region of Interest (ROI) on the camera preview.
		/// </summary>
		public string RoiLineColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(RoiLineColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(RoiLineColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetRoiLineColorRequested", (object)value);
				}
			}
		}

		public string ScanningIndicatorLineColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(ScanningIndicatorColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ScanningIndicatorColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetScanningIndicatorColorHexRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the hexadecimal color code representing the background color of the overlay within the Region of Interest (ROI) on the camera preview.
		/// </summary>
		public string RoiOverlayBackgroundColorHex
		{
			get
			{
				return (string)((BindableObject)this).GetValue(RoiOverlayBackgroundColorHexProperty);
			}
			set
			{
				((BindableObject)this).SetValue(RoiOverlayBackgroundColorHexProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetRoiOverlayBackgroundColorRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the character set used for encoding barcode data.
		/// </summary>
		public string EncodingCharacterSet
		{
			get
			{
				return (string)((BindableObject)this).GetValue(EncodingCharacterSetProperty);
			}
			set
			{
				((BindableObject)this).SetValue(EncodingCharacterSetProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetEncodingCharacterSetRequested", (object)value);
				}
			}
		}

		public string ARHeaderTextFormat
		{
			get
			{
				return (string)((BindableObject)this).GetValue(ARHeaderTextFormatProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARHeaderTextFormatProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARHeaderTextFormatRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the current width setting for the lines indicating the location of detected barcodes on the camera feed.
		/// </summary>
		public double LocationLineWidth
		{
			get
			{
				return (double)((BindableObject)this).GetValue(LocationLineWidthProperty);
			}
			set
			{
				((BindableObject)this).SetValue(LocationLineWidthProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetLocationLineWidthRequested", (object)value);
				}
			}
		}

		public double ARSelectedLocationLineWidth
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ARSelectedLocationLineWidthProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARSelectedLocationLineWidthProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARSelectedLocationLineWidthRequested", (object)value);
				}
			}
		}

		public double ARNonSelectedLocationLineWidth
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ARNonSelectedLocationLineWidthProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARNonSelectedLocationLineWidthProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARNonSelectedLocationLineWidthRequested", (object)value);
				}
			}
		}

		public double ARLocationTransitionSpeed
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ARLocationTransitionSpeedProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARLocationTransitionSpeedProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARLocationTransitionSpeedRequested", (object)value);
				}
			}
		}

		public double ScanningIndicatorLineWidth
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ScanningIndicatorLineWidthProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ScanningIndicatorLineWidthProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetScanningIndicatorLineWidthRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the current width setting for the lines outlining the Region of Interest (ROI) on the camera preview.
		/// </summary>
		public double RoiLineWidth
		{
			get
			{
				return (double)((BindableObject)this).GetValue(RoiLineWidthProperty);
			}
			set
			{
				((BindableObject)this).SetValue(RoiLineWidthProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetRoiLineWidthRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks or sets if image result is enabled.
		/// </summary>
		public bool ImageResultEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(ImageResultEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ImageResultEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetImageResultEnabledRequested", (object)value);
				}
			}
		}

		public bool ARImageResultEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(ARImageResultEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARImageResultEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARImageResultEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks or sets if location in image result is enabled.
		/// </summary>
		public bool LocationInImageResultEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(LocationInImageResultEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(LocationInImageResultEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetLocationInImageResultEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks if location in preview is enabled.
		/// </summary>
		public bool LocationInPreviewEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(LocationInPreviewEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(LocationInPreviewEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetLocationInPreviewEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks or sets if pinch to zoom is enabled.
		/// </summary>
		public bool PinchToZoomEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(PinchToZoomEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(PinchToZoomEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetPinchToZoomEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether a beep sound is played on successful barcode scanning.
		/// </summary>
		public bool BeepOnSuccessEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(BeepOnSuccessEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BeepOnSuccessEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBeepOnSuccessEnabledRequested", (object)value);
				}
			}
		}

		public bool ScanningIndicatorAlwaysVisibleEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(ScanningIndicatorAlwaysVisibleProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ScanningIndicatorAlwaysVisibleProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetScanningIndicatorAlwaysVisibleRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether vibration is enabled on successful barcode scanning.
		/// </summary>
		public bool VibrateOnSuccessEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(VibrateOnSuccessEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(VibrateOnSuccessEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetVibrateOnSuccessEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the session is closed upon detecting a result during barcode scanning.
		/// </summary>
		public bool CloseSessionOnResultEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(CloseSessionOnResultEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(CloseSessionOnResultEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetCloseSessionOnResultEnabledRequested", (object)value);
				}
			}
		}

		public bool ARContinueScanningOnLimit
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(ARContinueScanningOnLimitProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARContinueScanningOnLimitProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARContinueScanningOnLimitRequested", (object)value);
				}
			}
		}

		public bool AREmitResultsAtSessionEndOnly
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(AREmitResultsAtSessionEndOnlyProperty);
			}
			set
			{
				((BindableObject)this).SetValue(AREmitResultsAtSessionEndOnlyProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetAREmitResultsAtSessionEndOnlyRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the resolution for barcode scanning.
		/// </summary>
		public Plugin.Maui.Barkoder.Enums.BarkoderResolution BarkoderResolution
		{
			get
			{
				return (Plugin.Maui.Barkoder.Enums.BarkoderResolution)((BindableObject)this).GetValue(BarkoderResolutionProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BarkoderResolutionProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarkoderResolutionRequested", (object)value);
				}
			}
		}

		public Plugin.Maui.Barkoder.Enums.BarkoderARMode BarkoderARMode
		{
			get
			{
				return (Plugin.Maui.Barkoder.Enums.BarkoderARMode)((BindableObject)this).GetValue(BarkoderARModeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BarkoderARModeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarkoderARModeRequested", (object)value);
				}
			}
		}

		public Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode BarkoderARHeaderShowMode
		{
			get
			{
				return (Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode)((BindableObject)this).GetValue(BarkoderARHeaderShowModeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BarkoderARHeaderShowModeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarkoderARHeaderShowModeRequested", (object)value);
				}
			}
		}

		public Plugin.Maui.Barkoder.Enums.BarkoderARLocationType BarkoderARLocationType
		{
			get
			{
				return (Plugin.Maui.Barkoder.Enums.BarkoderARLocationType)((BindableObject)this).GetValue(BarkoderARLocationTypeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BarkoderARLocationTypeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarkoderARLocationTypeRequested", (object)value);
				}
			}
		}

		public Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh BarkoderAROverlayRefresh
		{
			get
			{
				return (Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh)((BindableObject)this).GetValue(BarkoderARoverlayRefreshProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BarkoderARoverlayRefreshProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarkoderARoverlayRefreshRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the current decoding speed setting for barcode scanning.
		/// </summary>
		public DecodingSpeed DecodingSpeed
		{
			get
			{
				return (DecodingSpeed)((BindableObject)this).GetValue(DecodingSpeedProperty);
			}
			set
			{
				((BindableObject)this).SetValue(DecodingSpeedProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetDecodingSpeedRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the formatting type used for presenting decoded barcode data..
		/// </summary>
		public FormattingType FormattingType
		{
			get
			{
				return (FormattingType)((BindableObject)this).GetValue(FormattingTypeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(FormattingTypeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetFormattingTypeRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the MSI checksum type.
		/// </summary>
		public MsiChecksumType MsiChecksumType
		{
			get
			{
				return (MsiChecksumType)((BindableObject)this).GetValue(MsiChecksumTypeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(MsiChecksumTypeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetMsiChecksumTypeRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the Code11 checksum type.
		/// </summary>
		public Code11ChecksumType Code11ChecksumType
		{
			get
			{
				return (Code11ChecksumType)((BindableObject)this).GetValue(Code11ChecksumTypeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(Code11ChecksumTypeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetCode11ChecksumTypeRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the checksum type for Code 39 barcodes.
		/// </summary>
		public Code39ChecksumType Code39ChecksumType
		{
			get
			{
				return (Code39ChecksumType)((BindableObject)this).GetValue(Code39ChecksumTypeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(Code39ChecksumTypeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetCode39ChecksumTypeRequested", (object)value);
				}
			}
		}

		public bool IdDocumentMasterCheckSumEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(IdDocumentMasterChecksumEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(IdDocumentMasterChecksumEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetIdDocumentMasterChecksumEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether Direct Part Marking (DPM) mode is enabled for Datamatrix barcodes.
		/// </summary>
		public bool DatamatrixDpmModeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(DatamatrixDpmModeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(DatamatrixDpmModeEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetDatamatrixDpmModeEnabledRequested", (object)value);
				}
			}
		}

		public bool QRDpmModeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(QRDpmModeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(QRDpmModeEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetQRDpmModeEnabledRequested", (object)value);
				}
			}
		}

		public bool QRMIcroDpmModeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(QRMicroDpmModeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(QRMicroDpmModeEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetQRMicroDpmModeEnabledRequested", (object)value);
				}
			}
		}

		public bool IsIdDocumentMasterChecksumEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(IsIdDocumentMasterChecksumEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(IsIdDocumentMasterChecksumEnabledProperty, (object)value);
			}
		}

		public bool IsDatamatrixDpmModeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(IsDatamatrixDpmModeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(IsDatamatrixDpmModeEnabledProperty, (object)value);
			}
		}

		public bool IsQRDpmModeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(IsQRDpmModeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(IsQRDpmModeEnabledProperty, (object)value);
			}
		}

		public bool IsQRMicroDpmModeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(IsQRMicroDpmModeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(IsQRMicroDpmModeEnabledProperty, (object)value);
			}
		}

		/// <summary>
		/// Sets or retrieves the value indicating whether deblurring is enabled for UPC/EAN barcodes.
		/// </summary>
		public bool UpcEanDeblurEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(UpcEanDeblurEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(UpcEanDeblurEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetUpcEanDeblurEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks if the detection of misshaped 1D barcodes is enabled.
		/// </summary>
		public bool EnableMisshaped1DEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(EnableMisshaped1DEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(EnableMisshaped1DEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetEnableMisshaped1DEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Checks if the barcode thumbnail on result is enabled.
		/// </summary>
		public bool BarcodeThumbnailOnResultEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(BarcodeThumbnailOnResultEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(BarcodeThumbnailOnResultEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarcodeThumbnailOnResultEnabledRequested", (object)value);
				}
			}
		}

		public bool ARBarcodeThumbnailOnResultEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(ARBarcodeThumbnailOnResultEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARBarcodeThumbnailOnResultEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARBarcodeThumbnailOnResultEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves the maximum number of results to be returned from barcode scanning at once.
		/// </summary>
		public int MaximumResultsCount
		{
			get
			{
				return (int)((BindableObject)this).GetValue(MaximumResultsCountProperty);
			}
			set
			{
				((BindableObject)this).SetValue(MaximumResultsCountProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetMaximumResultsCountRequested", (object)value);
				}
			}
		}

		public int ARResultLimit
		{
			get
			{
				return (int)((BindableObject)this).GetValue(ARResultLimitProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARResultLimitProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARResultLimitRequested", (object)value);
				}
			}
		}

		public int ResultDisappearanceDelayMs
		{
			get
			{
				return (int)((BindableObject)this).GetValue(ResultDisappearanceDelayMsProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ResultDisappearanceDelayMsProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetResultDisappearanceDelayMsRequested", (object)value);
				}
			}
		}

		public double HeaderARVerticalTextMargin
		{
			get
			{
				return (double)((BindableObject)this).GetValue(HeaderARVerticalTextMarginProperty);
			}
			set
			{
				((BindableObject)this).SetValue(HeaderARVerticalTextMarginProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARHeaderVerticalTextMarginRequested", (object)value);
				}
			}
		}

		public double HeaderARHorizontalTextMargin
		{
			get
			{
				return (double)((BindableObject)this).GetValue(HeaderARHorizontalTextMarginProperty);
			}
			set
			{
				((BindableObject)this).SetValue(HeaderARHorizontalTextMarginProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARHeaderHorizontalTextMarginRequested", (object)value);
				}
			}
		}

		public double ARHeaderHeight
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ARHeaderHeightProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARHeaderHeightProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARHeaderHeightRequested", (object)value);
				}
			}
		}

		public double ARHeaderMaxTextHeight
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ARHeaderMaxTextHeightProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARHeaderMaxTextHeightProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARHeaderMaxTextHeightRequested", (object)value);
				}
			}
		}

		public double ARHeaderMinTextHeight
		{
			get
			{
				return (double)((BindableObject)this).GetValue(ARHeaderMinTextHeightProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARHeaderMinTextHeightProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARHeaderMinTextHeightRequested", (object)value);
				}
			}
		}

		public int ScanningIndicatorAnimationMode
		{
			get
			{
				return (int)((BindableObject)this).GetValue(ScanningIndicatorAnimationModeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ScanningIndicatorAnimationModeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetScanningIndicatorAnimationModeRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the delay in milliseconds for considering duplicate barcodes during scanning.
		/// </summary>
		private int DuplicatesDelayMs
		{
			get
			{
				return (int)((BindableObject)this).GetValue(DuplicatesDelayMsProperty);
			}
			set
			{
				((BindableObject)this).SetValue(DuplicatesDelayMsProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetDuplicatesDelayMsRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Sets or checks if VIN restrictions are enabled.
		/// </summary>
		public bool VINRestrictionsEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(VINRestrictionsEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(VINRestrictionsEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetEnableVINRestrictionsRequested", (object)value);
				}
			}
		}

		public bool ARDoubleTapToFreezeEnabled
		{
			get
			{
				return (bool)((BindableObject)this).GetValue(ARDoubleTapToFreezeEnabledProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ARDoubleTapToFreezeEnabledProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetARDoubleTapToFreezeEnabledRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves the threshold between duplicate scans.
		/// </summary>
		public int ThresholdBetweenDuplicatesScans
		{
			get
			{
				return (int)((BindableObject)this).GetValue(ThresholdBetweenDuplicatesScansProperty);
			}
			set
			{
				((BindableObject)this).SetValue(ThresholdBetweenDuplicatesScansProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetThresholdBetweenDuplicatesScansRequested", (object)value);
				}
			}
		}

		public int EnableComposite
		{
			get
			{
				return (int)((BindableObject)this).GetValue(EnableCompositeProperty);
			}
			set
			{
				((BindableObject)this).SetValue(EnableCompositeProperty, (object)value);
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetEnableCompositeRequested", (object)value);
				}
			}
		}

		/// <summary>
		/// Retrieves or sets the region of interest (ROI).
		/// </summary>
		public (int, int, int, int) RegionOfInterest
		{
			get
			{
				return ((int, int, int, int))((BindableObject)this).GetValue(RegionOfInterestProperty);
			}
			set
			{
				((BindableObject)this).SetValue(RegionOfInterestProperty, (object)value);
				int[] array = new int[4] { value.Item1, value.Item2, value.Item3, value.Item4 };
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetRegionOfInterestRequested", (object)array);
				}
			}
		}

		public event EventHandler? StartCameraRequested;

		public event EventHandler<IBarkoderDelegate>? StartScanningRequested;

		public event EventHandler<IBarkoderDelegate>? ScanImageRequest;

		public event EventHandler? StopScanningRequested;

		public event EventHandler? SelectVisibleBarcodesRequested;

		public event EventHandler? ConfigureCloseButtonRequested;

		public event EventHandler? ConfigureFlashButtonRequested;

		public event EventHandler? ConfigureZoomButtonRequested;

		public event EventHandler? CaptureImageRequested;

		public event EventHandler? PauseScanningRequested;

		public event EventHandler? FreezeScanningRequested;

		public event EventHandler? UnfreezeScanningRequested;

		public event EventHandler<bool>? FlashEnableRequested;

		public event EventHandler<float>? SetZoomFactorRequested;

		public event EventHandler<bool>? SetPinchToZoomEnabledRequested;

		public event EventHandler<bool>? SetRegionOfInterestVisibleRequested;

		public event EventHandler<float>? SetRoiLineWidthRequested;

		public event EventHandler<bool>? SetCloseSessionOnResultEnabledRequested;

		public event EventHandler<bool>? SetARContinueScanningOnLimitRequested;

		public event EventHandler<bool>? SetAREmitResultsAtSessionEndOnlyRequested;

		public event EventHandler<bool>? SetImageResultEnabledRequested;

		public event EventHandler<bool>? SetARImageResultEnabledRequested;

		public event EventHandler<bool>? SetLocationInPreviewEnabledRequested;

		public event EventHandler<bool>? SetLocationInImageResultEnabledRequested;

		public event EventHandler<bool>? SetBeepOnSuccessEnabledRequested;

		public event EventHandler<bool>? SetScanningIndicatorAlwaysVisibleRequested;

		public event EventHandler<bool>? SetVibrateOnSuccessEnabledRequested;

		public event EventHandler<string>? SetLocationLineColorRequested;

		public event EventHandler<string>? SetARSelectedLocationLineColorRequested;

		public event EventHandler<string>? SetARNonSelectedLocationLineColorRequested;

		public event EventHandler<string>? SetARNonSelectedHeaderTextColorRequested;

		public event EventHandler<string>? SetARSelectedHeaderTextColorRequested;

		public event EventHandler<double>? SetARHeaderVerticalTextMarginRequested;

		public event EventHandler<double>? SetARHeaderHorizontalTextMarginRequested;

		public event EventHandler<string>? SetRoiLineColorRequested;

		public event EventHandler<string>? SetRoiOverlayBackgroundColorRequested;

		public event EventHandler<string>? SetScanningIndicatorColorHexRequested;

		public event EventHandler<double>? SetLocationLineWidthRequested;

		public event EventHandler<double>? SetARSelectedLocationLineWidthRequested;

		public event EventHandler<double>? SetARNonSelectedLocationLineWidthRequested;

		public event EventHandler<double>? SetARLocationTransitionSpeedRequested;

		public event EventHandler<double>? SetScanningIndicatorLineWidthRequested;

		public event EventHandler<int[]>? SetRegionOfInterestRequested;

		public event EventHandler<Plugin.Maui.Barkoder.Enums.BarkoderResolution>? SetBarkoderResolutionRequested;

		public event EventHandler<Plugin.Maui.Barkoder.Enums.BarkoderARMode>? SetBarkoderARModeRequested;

		public event EventHandler<Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode>? SetBarkoderARHeaderShowModeRequested;

		public event EventHandler<Plugin.Maui.Barkoder.Enums.BarkoderARLocationType>? SetBarkoderARLocationTypeRequested;

		public event EventHandler<Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh>? SetBarkoderARoverlayRefreshRequested;

		public event EventHandler<DecodingSpeed>? SetDecodingSpeedRequested;

		public event EventHandler<FormattingType>? SetFormattingTypeRequested;

		public event EventHandler<MsiChecksumType>? SetMsiChecksumTypeRequested;

		public event EventHandler<MsiChecksumType>? SetCode11ChecksumTypeRequested;

		public event EventHandler<MsiChecksumType>? SetCode39ChecksumTypeRequested;

		public event EventHandler<bool>? SetIdDocumentMasterChecksumEnabledRequested;

		public event EventHandler<string>? SetEncodingCharacterSetRequested;

		public event EventHandler<string>? SetARHeaderTextFormatRequested;

		public event EventHandler<bool>? SetDatamatrixDpmModeEnabledRequested;

		public event EventHandler<bool>? SetQRDpmModeEnabledRequested;

		public event EventHandler<bool>? SetQRMicroDpmModeEnabledRequested;

		public event EventHandler<bool>? SetUpcEanDeblurEnabledRequested;

		public event EventHandler<bool>? SetEnableMisshaped1DEnabledRequested;

		public event EventHandler<bool>? SetBarcodeThumbnailOnResultEnabledRequested;

		public event EventHandler<bool>? SetARBarcodeThumbnailOnResultEnabledRequested;

		public event EventHandler<int>? SetMaximumResultsCountRequested;

		public event EventHandler<int>? SetARResultLimitRequested;

		public event EventHandler<int>? SetResultDisappearanceDelayMsRequested;

		public event EventHandler<double>? SetARHeaderHeightRequested;

		public event EventHandler<double>? SetARHeaderMaxTextHeightRequested;

		public event EventHandler<double>? SetARHeaderMinTextHeightRequested;

		public event EventHandler<int>? SetScanningIndicatorAnimationModeRequested;

		public event EventHandler<int>? SetDuplicatesDelayMsRequested;

		public event EventHandler<BarcodeTypeEventArgs>? SetBarcodeTypeEnabledRequested;

		public event EventHandler<bool>? SetEnableVINRestrictionsRequested;

		public event EventHandler<bool>? SetARDoubleTapToFreezeEnabledRequested;

		public event EventHandler<int>? SetThresholdBetweenDuplicatesScansRequested;

		public event EventHandler<int>? SetEnableCompositeRequested;

		public event EventHandler<BarcodeRangeEventArg>? SetBarcodeTypeLengthRangeRequested;

		public event EventHandler<string>? ConfigureBarkoderRequested;

		/// <summary>
		/// Initializes a new instance of the BarkoderView class.
		/// </summary>
		public BarkoderView()
		{
			BarcodeTypes = new List<BarcodeTypeEventArgs>();
			foreach (BarcodeType value in Enum.GetValues(typeof(BarcodeType)))
			{
				BarcodeTypes.Add(new BarcodeTypeEventArgs(value, enabled: false));
			}
		}

		public void SetCustomOption(string optionName, int optionValue)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetCustomOption", (object)(optionName, optionValue));
			}
		}

		public void SetDynamicExposure(int dynamicExposure)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetDynamicExposure", (object)dynamicExposure);
			}
		}

		public void SetCamera(Plugin.Maui.Barkoder.Enums.BarkoderCameraPosition position)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetCamera", (object)position);
			}
		}

		public void SetCentricFocusAndExposure(bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetCentricFocusAndExposure", (object)enabled);
			}
		}

		public void SetUPCE1expandToUPCA(bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetUPCE1expandToUPCA", (object)enabled);
			}
		}

		public void SetUPCEexpandToUPCA(bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetUPCEexpandToUPCA", (object)enabled);
			}
		}

		public void SetVideoStabilization(bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetVideoStabilization", (object)enabled);
			}
		}

		public void InitCameraProperties()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("InitCameraProperties", (object)null);
			}
		}

		public void SetShowDuplicatesLocation(bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetShowDuplicatesLocation", (object)enabled);
			}
		}

		public float GetCurrentZoomFactor()
		{
			if (((VisualElement)this).Handler is BarkoderViewHandler barkoderViewHandler)
			{
				return barkoderViewHandler.GetCurrentZoomFactor();
			}
			return -1f;
		}

		/// <summary>
		/// Starts the camera for barcode scanning.
		/// </summary>
		public void StartCamera()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("StartCameraRequested", (object)null);
			}
		}

		/// <summary>
		/// Initiates the barcode scanning process, allowing the application to detect and decode barcodes from the device's camera feed.
		/// </summary>
		/// <param name="barkoderDelegate">The delegate to handle barcode scanning events.</param>
		public void StartScanning(IBarkoderDelegate barkoderDelegate)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("StartScanningRequested", (object)barkoderDelegate);
			}
		}

		public void ScanImage(string base64Image, IBarkoderDelegate barkoderDelegate)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("ScanImageRequest", (object)new { base64Image, barkoderDelegate });
			}
		}

		/// <summary>
		/// Halts the barcode scanning process, stopping the camera from capturing and processing barcode information.
		/// </summary>
		public void StopScanning()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("StopScanningRequested", (object)null);
			}
		}

		public void SelectVisibleBarcodes()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SelectVisibleBarcodesRequested", (object)null);
			}
		}

		public void ConfigureCloseButton(bool visible, float[] position, float iconSize, string? tintColor, string? backgroundColor, float cornerRadius, float padding, bool useCustomIcon, string customIconBase64, Action? onClose)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("ConfigureCloseButtonRequested", (object)new { visible, position, iconSize, tintColor, backgroundColor, cornerRadius, padding, useCustomIcon, customIconBase64, onClose });
			}
		}

		public void ConfigureFlashButton(bool visible, float[] position, float iconSize, string? tintColor, string? backgroundColor, float cornerRadius, float padding, bool useCustomIcon, string? customIconFlashOnBase64, string? customIconFlashOffBase64)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("ConfigureFlashButtonRequested", (object)new { visible, position, iconSize, tintColor, backgroundColor, cornerRadius, padding, useCustomIcon, customIconFlashOnBase64, customIconFlashOffBase64 });
			}
		}

		public void ConfigureZoomButton(bool visible, float[] position, float iconSize, string? tintColor, string? backgroundColor, float cornerRadius, float padding, bool useCustomIcon, string? customIconZoomedInBase64, string? customIconZoomedOutBase64, float zoomedInFactor, float zoomedOutFactor)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("ConfigureZoomButtonRequested", (object)new
				{
					visible, position, iconSize, tintColor, backgroundColor, cornerRadius, padding, useCustomIcon, customIconZoomedInBase64, customIconZoomedOutBase64,
					zoomedInFactor, zoomedOutFactor
				});
			}
		}

		public void CaptureImage()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("CaptureImageRequested", (object)null);
			}
		}

		/// <summary>
		/// Temporarily suspends the barcode scanning process, pausing the camera feed without completely stopping the scanning session.
		/// </summary>
		public void PauseScanning()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("PauseScanningRequested", (object)null);
			}
		}

		public void UnfreezeScanning()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("UnfreezeScanningRequested", (object)null);
			}
		}

		public void FreezeScanning()
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("FreezeScanningRequested", (object)null);
			}
		}

		/// <summary>
		/// Enables or disables the device's flash (torch) for illumination during barcode scanning.
		/// </summary>
		/// <param name="enabled">True to enable the flash, false to disable it.</param>
		public void SetFlashEnabled(bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("FlashEnableRequested", (object)enabled);
			}
		}

		/// <summary>
		/// Sets the zoom factor for the device's camera, adjusting the level of zoom during barcode scanning.
		/// </summary>
		/// <param name="zoomFactor">The zoom factor to set.</param>
		public void SetZoomFactor(float zoomFactor)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetZoomFactorRequested", (object)zoomFactor);
			}
		}

		/// <summary>
		/// Enables or disables the pinch-to-zoom feature for adjusting the zoom level during barcode scanning.
		/// </summary>
		/// <param name="enabled">True to enable pinch-to-zoom, false to disable it.</param>
		public void SetPinchToZoomEnabled(bool enabled)
		{
			PinchToZoomEnabled = enabled;
		}

		/// <summary>
		/// Sets the visibility of the Region of Interest (ROI) on the camera preview.
		/// </summary>
		/// <param name="visible">True to make the ROI visible, false to hide it.</param>
		public void SetRegionOfInterestVisible(bool visible)
		{
			RegionOfInterestVisible = visible;
		}

		/// <summary>
		/// Enables or disables the automatic closing of the scanning session upon detecting a barcode result.
		/// </summary>
		/// <param name="enabled">True to close the session on result detection, false otherwise.</param>
		public void SetCloseSessionOnResultEnabled(bool enabled)
		{
			CloseSessionOnResultEnabled = enabled;
		}

		public void SetARContinueScanningOnLimit(bool enabled)
		{
			ARContinueScanningOnLimit = enabled;
		}

		public void SetAREmitResultsAtSessionEndOnly(bool enabled)
		{
			AREmitResultsAtSessionEndOnly = enabled;
		}

		/// <summary>
		/// Enables or disables the capturing and processing of image data when a barcode is successfully detected.
		/// </summary>
		/// <param name="enabled">True to enable image result display, false to disable it.</param>
		public void SetImageResultEnabled(bool enabled)
		{
			ImageResultEnabled = enabled;
		}

		public void SetARImageResultEnabled(bool enabled)
		{
			ARImageResultEnabled = enabled;
		}

		/// <summary>
		/// Enables or disables the display of barcode location information on the camera preview.
		/// </summary>
		/// <param name="enabled">True to display the location, false to hide it.</param>
		public void SetLocationInPreviewEnabled(bool enabled)
		{
			LocationInPreviewEnabled = enabled;
		}

		/// <summary>
		/// Enables or disables the inclusion of barcode location information within the image data result.
		/// </summary>
		/// <param name="enabled">True to display the location, false to hide it.</param>
		public void SetLocationInImageResultEnabled(bool enabled)
		{
			LocationInImageResultEnabled = enabled;
		}

		/// <summary>
		/// Enables or disables the audible beep sound upon successfully decoding a barcode.
		/// </summary>
		/// <param name="enabled">True to enable beep sound, false to disable it.</param>
		public void SetBeepOnSuccessEnabled(bool enabled)
		{
			BeepOnSuccessEnabled = enabled;
		}

		public void SetScanningIndicatorAlwaysVisibleEnabled(bool enabled)
		{
			ScanningIndicatorAlwaysVisibleEnabled = enabled;
		}

		/// <summary>
		/// Retrieves or sets the value indicating whether vibration is enabled on successful barcode scanning.
		/// </summary>
		/// <param name="enabled">True to enable vibration, false to disable it.</param>
		public void SetVibrateOnSuccessEnabled(bool enabled)
		{
			VibrateOnSuccessEnabled = enabled;
		}

		/// <summary>
		/// Sets the color of the lines used to indicate the location of detected barcodes on the camera feed.
		/// </summary>
		/// <param name="hexColor">The hexadecimal representation of the color.</param>
		public void SetLocationLineColor(string hexColor)
		{
			LocationLineColorHex = hexColor;
		}

		public void SetARSelectedLocationLineColor(string hexColor)
		{
			ARSelectedLocationLineColorHex = hexColor;
		}

		public void SetARSelectedHeaderTextColor(string hexColor)
		{
			ARSelectedHeaderTextColorHex = hexColor;
		}

		public void SetARNonSelectedHeaderTextColor(string hexColor)
		{
			ARNonSelectedHeaderTextColorHex = hexColor;
		}

		public void SetARNonSelectedLocationLineColor(string hexColor)
		{
			ARNonSelectedLocationLineColorHex = hexColor;
		}

		/// <summary>
		/// Sets the color of the lines outlining the Region of Interest (ROI) for barcode scanning on the camera feed.
		/// </summary>
		/// <param name="hexColor">The hexadecimal representation of the color.</param>
		public void SetRoiLineColor(string hexColor)
		{
			RoiLineColorHex = hexColor;
		}

		public void SetScanningIndicatorColor(string hexColor)
		{
			ScanningIndicatorLineColorHex = hexColor;
		}

		/// <summary>
		/// Sets the background color of the overlay within the Region of Interest (ROI) for barcode scanning on the camera feed.
		/// </summary>
		/// <param name="hexColor">The hexadecimal representation of the color.</param>
		public void SetRoiOverlayBackgroundColor(string hexColor)
		{
			RoiOverlayBackgroundColorHex = hexColor;
		}

		/// <summary>
		/// Defines the Region of Interest (ROI) on the camera preview for barcode scanning, specifying an area where the application focuses on detecting barcodes.
		/// </summary>
		/// <param name="left">The left coordinate of the ROI.</param>
		/// <param name="top">The top coordinate of the ROI.</param>
		/// <param name="width">The width of the ROI.</param>
		/// <param name="height">The height of the ROI.</param>
		public void SetRegionOfInterest(int left, int top, int width, int height)
		{
			RegionOfInterest = (left, top, width, height);
		}

		/// <summary>
		/// Sets the resolution for barcode scanning.
		/// </summary>
		/// <param name="resolution">The resolution to be set.</param>
		public void SetBarkoderResolution(Plugin.Maui.Barkoder.Enums.BarkoderResolution resolution)
		{
			BarkoderResolution = resolution;
		}

		public void SetBarkoderARMode(Plugin.Maui.Barkoder.Enums.BarkoderARMode arMode)
		{
			BarkoderARMode = arMode;
		}

		public void SetBarkoderARHeaderShowMode(Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode headerShowMode)
		{
			BarkoderARHeaderShowMode = headerShowMode;
		}

		public void SetBarkoderARLocationType(Plugin.Maui.Barkoder.Enums.BarkoderARLocationType locationType)
		{
			BarkoderARLocationType = locationType;
		}

		public void SetBarkoderARoverlayRefresh(Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh overlayRefresh)
		{
			BarkoderAROverlayRefresh = overlayRefresh;
		}

		/// <summary>
		/// Sets the decoding speed for barcode scanning.
		/// </summary>
		/// <param name="decodingSpeed">The decoding speed to be set.</param>
		public void SetDecodingSpeed(DecodingSpeed decodingSpeed)
		{
			DecodingSpeed = decodingSpeed;
		}

		/// <summary>
		/// Sets the formatting type for barcode scanning.
		/// </summary>
		/// <param name="formattingType">The formatting type to be set.</param>
		public void SetFormattingType(FormattingType formattingType)
		{
			FormattingType = formattingType;
		}

		/// <summary>
		/// Sets the MSI checksum type.
		/// </summary>
		/// <param name="msiChecksumType">The MSI checksum type to be set.</param>
		public void SetMsiChecksumType(MsiChecksumType msiChecksumType)
		{
			MsiChecksumType = msiChecksumType;
		}

		/// <summary>
		/// Sets the Code11 checksum type.
		/// </summary>
		/// <param name="code11ChecksumType">The Code 11 checksum type to be set.</param>
		public void SetCode11ChecksumType(Code11ChecksumType code11ChecksumType)
		{
			Code11ChecksumType = code11ChecksumType;
		}

		/// <summary>
		/// Sets the Code39 checksum type.
		/// </summary>
		/// <param name="code39ChecksumType">The Code 39 checksum type to be set.</param>
		public void SetCode39ChecksumType(Code39ChecksumType code39ChecksumType)
		{
			Code39ChecksumType = code39ChecksumType;
		}

		/// <summary>
		/// Sets the encoding character set for barcode scanning.
		/// </summary>
		/// <param name="encodingCharacterSet">The encoding character set to be set.</param>
		public void SetEncodingCharacterSet(string encodingCharacterSet)
		{
			EncodingCharacterSet = encodingCharacterSet;
		}

		public void SetHeaderTextFormatAR(string headerTextformat)
		{
			ARHeaderTextFormat = headerTextformat;
		}

		public void SetIdDocumentMasterChecksumEnabled(bool enabled)
		{
			IdDocumentMasterCheckSumEnabled = enabled;
		}

		/// <summary>
		/// Sets whether the Direct Part Marking (DPM) mode for Datamatrix barcodes is enabled.
		/// </summary>
		/// <param name="enabled">True to enable DPM mode, false to disable it.</param>
		public void SetDatamatrixDpmModeEnabled(bool enabled)
		{
			DatamatrixDpmModeEnabled = enabled;
		}

		public void SetQRDpmModeEnabled(bool enabled)
		{
			QRDpmModeEnabled = enabled;
		}

		public void SetQRMicroDpmModeEnabled(bool enabled)
		{
			QRMIcroDpmModeEnabled = enabled;
		}

		/// <summary>
		/// Sets whether the deblurring feature for UPC/EAN barcodes is enabled.
		/// </summary>
		/// <param name="enabled">True to enable deblurring, false to disable it.</param>
		public void SetUpcEanDeblurEnabled(bool enabled)
		{
			UpcEanDeblurEnabled = enabled;
		}

		/// <summary>
		/// Sets whether the detection of misshaped 1D barcodes is enabled.
		/// </summary>
		/// <param name="enabled">True to enable decoding, false to disable it.</param>
		public void SetEnableMisshaped1DEnabled(bool enabled)
		{
			EnableMisshaped1DEnabled = enabled;
		}

		/// <summary>
		/// Sets whether to enable barcode thumbnail on result.
		/// </summary>
		/// <param name="enabled">True to enable barcode thumbnails, false to disable them.</param>
		public void SetBarcodeThumbnailOnResultEnabled(bool enabled)
		{
			BarcodeThumbnailOnResultEnabled = enabled;
		}

		public void SetARBarcodeThumbnailOnResultEnabled(bool enabled)
		{
			ARBarcodeThumbnailOnResultEnabled = enabled;
		}

		/// <summary>
		/// Sets the maximum number of results to be returned from barcode scanning.
		/// </summary>
		/// <param name="maximumResultsCount">The maximum number of results to return.</param>
		public void SetMaximumResultsCount(int maximumResultsCount)
		{
			MaximumResultsCount = maximumResultsCount;
		}

		public void SetARResultLimit(int resultLimit)
		{
			ARResultLimit = resultLimit;
		}

		public void SetResultDisappearanceDelayMs(int resultDisappearanceDelayMs)
		{
			ResultDisappearanceDelayMs = resultDisappearanceDelayMs;
		}

		public void SetARHeaderVerticalTextMargin(double verticalTextMargin)
		{
			HeaderARVerticalTextMargin = verticalTextMargin;
		}

		public void SetARHeaderHorizontalTextMargin(double horizontalTextMargin)
		{
			HeaderARHorizontalTextMargin = horizontalTextMargin;
		}

		public void SetARHeaderHeight(double headerHeight)
		{
			ARHeaderHeight = headerHeight;
		}

		public void SetARHeaderTextFormat(string headerTextFormat)
		{
			ARHeaderTextFormat = headerTextFormat;
		}

		public void SetARLocationTransitionSpeed(double transitionSpeed)
		{
			ARLocationTransitionSpeed = transitionSpeed;
		}

		public void SetARSelectedLocationLineWidth(double locationWidth)
		{
			ARSelectedLocationLineWidth = locationWidth;
		}

		public void SetARNonSelectedLocationLineWidth(double locationWidth)
		{
			ARNonSelectedLocationLineWidth = locationWidth;
		}

		public void SetARHeaderMaxTextHeight(double headerHeightMaxText)
		{
			ARHeaderMaxTextHeight = headerHeightMaxText;
		}

		public void SetARHeaderMinTextHeight(double headerHeightMinText)
		{
			ARHeaderMinTextHeight = headerHeightMinText;
		}

		public void SetScanningIndicatorAnimationMode(int animationMode)
		{
			ScanningIndicatorAnimationMode = animationMode;
		}

		/// <summary>
		/// Sets whether a specific barcode type is enabled.
		/// </summary>
		/// <param name="barcodeType">The barcode type to enable or disable.</param>
		/// <param name="enabled">True to enable the barcode type, false to disable it.</param>
		public void SetBarcodeTypeEnabled(BarcodeType barcodeType, bool enabled)
		{
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("SetBarcodeTypeEnabledRequested", (object)new BarcodeTypeEventArgs(barcodeType, enabled));
			}
			for (int i = 0; i < BarcodeTypes.Count; i++)
			{
				if (BarcodeTypes[i].BarcodeType == barcodeType)
				{
					BarcodeTypes[i] = new BarcodeTypeEventArgs(barcodeType, enabled);
				}
			}
		}

		/// <summary>
		/// Sets whether Vehicle Identification Number (VIN) restrictions are enabled.
		/// </summary>
		/// <param name="enabled">True to enable VIN restrictions, false to disable them.</param>
		public void SetEnableVINRestrictions(bool enabled)
		{
			VINRestrictionsEnabled = enabled;
		}

		public void SetARDoubleTapToFreezeEnabled(bool enabled)
		{
			ARDoubleTapToFreezeEnabled = enabled;
		}

		/// <summary>
		/// Sets the threshold between duplicate scans.
		/// </summary>
		/// <param name="thresholdBetweenDuplicatesScans">The threshold between duplicate scans in milliseconds.</param>
		public void SetThresholdBetweenDuplicatesScans(int thresholdBetweenDuplicatesScans)
		{
			ThresholdBetweenDuplicatesScans = thresholdBetweenDuplicatesScans;
		}

		public void SetEnableComposite(int enableComposite)
		{
			EnableComposite = enableComposite;
		}

		/// <summary>
		/// Checks if a specific barcode type is enabled.
		/// </summary>
		/// <param name="barcode">The barcode type to check.</param>
		/// <returns>True if the barcode type is enabled; otherwise, false.</returns>
		public bool IsBarcodeTypeEnabled(BarcodeType barcode)
		{
			foreach (BarcodeTypeEventArgs barcodeType in BarcodeTypes)
			{
				if (barcodeType.BarcodeType == barcode)
				{
					return barcodeType.Enabled;
				}
			}
			return false;
		}

		/// <summary>
		/// Sets the length range for the specified barcode type.
		/// </summary>
		/// <param name="barcodeType">The type of barcode.</param>
		/// <param name="min">The minimum length of the barcode.</param>
		/// <param name="max">The maximum length of the barcode.</param>
		public void SetBarcodeTypeLengthRange(BarcodeType barcodeType, int min, int max)
		{
			if ((uint)(barcodeType - 4) <= 5u)
			{
				IViewHandler handler = ((VisualElement)this).Handler;
				if (handler != null)
				{
					((IElementHandler)handler).Invoke("SetBarcodeTypeLengthRangeRequested", (object)new BarcodeRangeEventArg(barcodeType, min, max));
				}
			}
		}

		/// <summary>
		/// Configures the Barkoder functionality based on the provided configuration.
		/// </summary>
		/// <param name="BarkoderConfig">The configuration parameters for the Barkoder.</param>
		public void ConfigureBarkoder(global::Barkoder.BarkoderConfig BarkoderConfig)
		{
			string text = JsonConvert.SerializeObject((object)BarkoderConfig);
			IViewHandler handler = ((VisualElement)this).Handler;
			if (handler != null)
			{
				((IElementHandler)handler).Invoke("ConfigureBarkoderRequested", (object)text);
			}
		}
	}
	public class BarcodeTypeEventArgs : EventArgs
	{
		public BarcodeType BarcodeType { get; }

		public bool Enabled { get; }

		public BarcodeTypeEventArgs(BarcodeType barcodeType, bool enabled)
		{
			BarcodeType = barcodeType;
			Enabled = enabled;
		}
	}
	public class BarcodeRangeEventArg : EventArgs
	{
		public BarcodeType BarcodeType { get; }

		public int Min { get; }

		public int Max { get; }

		public BarcodeRangeEventArg(BarcodeType barcodeType, int min, int max)
		{
			BarcodeType = barcodeType;
			Min = min;
			Max = max;
		}
	}
	public class BarkoderViewHandler : ViewHandler<BarkoderView, View>
	{
		private Com.Barkoder.BarkoderView? BKDView;

		public static IPropertyMapper<BarkoderView, BarkoderViewHandler> PropertyMapper = (IPropertyMapper<BarkoderView, BarkoderViewHandler>)(object)new PropertyMapper<BarkoderView, BarkoderViewHandler>((IPropertyMapper[])(object)new IPropertyMapper[1] { (IPropertyMapper)ViewHandler.ViewMapper })
		{
			["LicenseKey"] = MapLicenseKey,
			["RegionOfInterestVisible"] = MapRegionOfInterestVisible,
			["IsFlashAvailableProperty"] = MapIsFlashAvailable,
			["ARImageResultEnabled"] = MapARImageResultEnabled,
			["ARBarcodeThumbnailOnResultEnabled"] = MapARBarcodeThumbnailOnResultEnabled,
			["LocationLineColorHexProperty"] = MapLocationLineColorHex,
			["ARNonSelectedLocationLineColorHexProperty"] = MapARNonSelectedLocationLineColorHex,
			["ARSelectedLocationLineColorHexProperty"] = MapARSelectedLocationLineColorHex,
			["ARSelectedHeaderTextColorHexProperty"] = MapARSelectedHeaderTextColorHex,
			["ARNonSelectedHeaderTextColorHexProperty"] = MapARNonSelectedHeaderTextColorHex,
			["RoiLineColorHexProperty"] = MapRoiLineColorHex,
			["RoiOverlayBackgroundColorHexProperty"] = MapRoiOverlayBackgroundColorHex,
			["EncodingCharacterSetProperty"] = MapEncodingCharacterSet,
			["ARHeaderTextFormatProperty"] = MapARHeaderTextFormat,
			["LocationLineWidthProperty"] = MapLocationLineWidth,
			["ARSelectedLocationLineWidthProperty"] = MapARSelectedLocationLineWidth,
			["ARNonSelectedLocationLineWidthProperty"] = MapARNonSelectedLocationLineWidth,
			["ARLocationTransitionSpeedProperty"] = MapARLocationTransitionSpeed,
			["ImageResultEnabledProperty"] = MapImageResultEnabled,
			["LocationInImageResultEnabledProperty"] = MapLocationInImageResultEnabled,
			["LocationInPreviewEnabledProperty"] = MapLocationInPreviewEnabled,
			["PinchToZoomEnabledProperty"] = MapPinchToZoomEnabled,
			["BeepOnSuccessEnabledProperty"] = MapBeepOnSuccessEnabled,
			["VibrateOnSuccessEnabledProperty"] = MapVibrateOnSuccessEnabled,
			["CloseSessionOnResultEnabledProperty"] = MapCloseSessionOnResultEnabled,
			["ARContinueScanningOnLimitProperty"] = MapARContinueScanningOnLimit,
			["AREmitResultsAtSessionEndOnlyProperty"] = MapAREmitResultsAtSessionEndOnly,
			["ARResultLimitProperty"] = MapARResultLimit,
			["VersionProperty"] = MapVersion,
			["LibVersionProperty"] = MapLibVersion,
			["BarkoderResolutionProperty"] = MapBarkoderResolution,
			["BarkoderARModeProperty"] = MapBarkoderARMode,
			["BarkoderARHeaderShowModeProperty"] = MapBarkoderARHeaderShowMode,
			["BarkoderARLocationTypeProperty"] = MapBarkoderARLocationType,
			["DecodingSpeedProperty"] = MapDecodingSpeed,
			["FormattingTypeProperty"] = MapFormattingType,
			["MsiChecksumTypeProperty"] = MapMsiChecksumType,
			["Code11ChecksumTypeProperty"] = MapCode11ChecksumType,
			["Code39ChecksumTypeProperty"] = MapCode39ChecksumType,
			["DatamatrixDpmModeEnabledProperty"] = MapDatamatrixDpmModeEnabled,
			["ScanningIndicatorAlwaysVisibleProperty"] = MapScanningIndicatorAlwaysVisibleEnabled,
			["ScanningIndicatorAnimationModeProperty"] = MapScanningIndicatorAnimationMode,
			["ScanningIndicatorColorHexProperty"] = MapScanningIndicatorColor,
			["ScanningIndicatorLineWidthProperty"] = MapScanningIndicatorWidth,
			["DatamatrixDpmModeEnabledProperty"] = MapDatamatrixDpmModeEnabled,
			["IdDocumentMasterChecksumEnabledProperty"] = MapIdDocumentMasterChecksumEnabled,
			["QRDpmModeEnabledProperty"] = MapQRDpmModeEnabled,
			["QRMicroDpmModeEnabledProperty"] = MapQRMicroDpmModeEnabled,
			["UpcEanDeblurEnabledProperty"] = MapUpcEanDeblurEnabled,
			["EnableMisshaped1DEnabledProperty"] = MapEnableMisshaped1DEnabled,
			["BarcodeThumbnailOnResultEnabledProperty"] = MapBarcodeThumbnailOnResultEnabledProperty,
			["MaximumResultsCountProperty"] = MapMaximumResultsCount,
			["ResultDisappearanceDelayMsProperty"] = MapResultDisappearanceDelayMs,
			["HeaderARVerticalTextMarginProperty"] = MapARHeaderVerticalTextMargin,
			["HeaderARHorizontalTextMarginProperty"] = MapARHeaderHorizontalTextMargin,
			["ARHeaderHeightProperty"] = MapARHeaderHeight,
			["ARHeaderMaxTextHeightProperty"] = MapARHeaderMaxTextHeight,
			["ARHeaderMinTextHeightProperty"] = MapARHeaderMinTextHeight,
			["DuplicatesDelayMsProperty"] = MapDuplicatesDelayMs,
			["VINRestrictionsEnabledProperty"] = MapVINRestrictionsEnabled,
			["ARDoubleTapToFreezeEnabledProperty"] = MapARDoubleTapToFreezeEnabled,
			["ThresholdBetweenDuplicatesScansProperty"] = MapThresholdBetweenDuplicatesScans,
			["EnableCompositeProperty"] = MapEnableComposite,
			["RegionOfInterestProperty"] = MapRegionOfInterest
		};

		public static CommandMapper<BarkoderView, BarkoderViewHandler> CommandMapper = new CommandMapper<BarkoderView, BarkoderViewHandler>((CommandMapper)(object)ViewHandler.ViewCommandMapper)
		{
			["SetCustomOption"] = MapSetCustomOption,
			["SetDynamicExposure"] = MapSetDynamicExposure,
			["SetARImageResultEnabledRequested"] = MapSetARImageResultEnabled,
			["SetARBarcodeThumbnailOnResultEnabledRequested"] = MapSetARBarcodeThumbnailOnResultEnabled,
			["SetCamera"] = MapSetCamera,
			["SetCentricFocusAndExposure"] = MapSetCentricFocusAndExposure,
			["SetUPCE1expandToUPCA"] = MapSetUPCE1expandToUPCA,
			["SetShowDuplicatesLocation"] = MapSetShowDuplicatesLocation,
			["SetUPCEexpandToUPCA"] = MapSetUPCEexpandToUPCA,
			["SetVideoStabilization"] = MapSetVideoStabilization,
			["StartCameraRequested"] = MapStartCamera,
			["StartScanningRequested"] = MapStartScanning,
			["ScanImageRequest"] = MapScanImage,
			["StopScanningRequested"] = MapStopScanning,
			["SelectVisibleBarcodesRequested"] = MapSelectVisibleBarcodes,
			["ConfigureCloseButtonRequested"] = MapConfigureCloseButton,
			["ConfigureFlashButtonRequested"] = MapConfigureFlashButton,
			["ConfigureZoomButtonRequested"] = MapConfigureZoomButton,
			["CaptureImageRequested"] = MapCaptureImage,
			["PauseScanningRequested"] = MapPauseScanning,
			["FreezeScanningRequested"] = MapFreezeScanning,
			["UnfreezeScanningRequested"] = MapUnfreezeScanning,
			["FlashEnableRequested"] = MapFlashEnable,
			["SetZoomFactorRequested"] = MapSetZoomFactor,
			["SetPinchToZoomEnabledRequested"] = MapSetPinchToZoomEnabled,
			["SetRegionOfInterestVisibleRequested"] = MapSetRegionOfInterestVisible,
			["SetRoiLineWidthRequested"] = MapSetRoiLineWidth,
			["SetCloseSessionOnResultEnabledRequested"] = MapSetCloseSessionOnResult,
			["SetARContinueScanningOnLimitRequested"] = MapSetARContinueScanningOnLimit,
			["SetAREmitResultsAtSessionEndOnlyRequested"] = MapSetAREmitResultsAtSessionEndOnly,
			["SetImageResultEnabledRequested"] = MapSetImageResultEnabled,
			["SetLocationInPreviewEnabledRequested"] = MapSetLocationInPreviewEnabled,
			["SetLocationInImageResultEnabledRequested"] = MapSetLocationInImageResultEnabled,
			["SetBeepOnSuccessEnabledRequested"] = MapSetBeepOnSuccessEnabled,
			["SetVibrateOnSuccessEnabledRequested"] = MapSetVibrateOnSuccessEnabled,
			["SetLocationLineColorRequested"] = MapSetLocationLineColor,
			["InitCameraProperties"] = MapInitCameraProperties,
			["SetARNonSelectedLocationLineColorRequested"] = MapSetARNonSelectedLocationColor,
			["SetARSelectedLocationLineColorRequested"] = MapSetARSelectedLocationColor,
			["SetARSelectedHeaderTextColorRequested"] = MapSetARSelectedHeaderTextColor,
			["SetARNonSelectedHeaderTextColorRequested"] = MapSetARNonSelectedHeaderTextColor,
			["SetRoiLineColorRequested"] = MapSetRoiLineColor,
			["SetRoiOverlayBackgroundColorRequested"] = MapSetRoiOverlayBackgroundColor,
			["SetLocationLineWidthRequested"] = MapSetLocationLineWidth,
			["SetARNonSelectedLocationLineWidthRequested"] = MapSetARNonSelectedLocationLineWidth,
			["SetARLocationTransitionSpeedRequested"] = MapSetARLocationTransitionSpeed,
			["SetARSelectedLocationLineWidthRequested"] = MapSetARSelectedLocationLineWidth,
			["SetRegionOfInterestRequested"] = MapSetRegionOfInterest,
			["SetBarkoderResolutionRequested"] = MapSetBarkoderResolution,
			["SetBarkoderARModeRequested"] = MapSetBarkoderARMode,
			["SetBarkoderARHeaderShowModeRequested"] = MapSetBarkoderARHeaderShowMode,
			["SetBarkoderARLocationTypeRequested"] = MapSetBarkoderARLocationType,
			["SetBarkoderARoverlayRefreshRequested"] = MapSetBarkoderARoverlayRefresh,
			["SetDecodingSpeedRequested"] = MapSetDecodingSpeed,
			["SetFormattingTypeRequested"] = MapSetFormattingType,
			["SetMsiChecksumTypeRequested"] = MapSetMsiChecksumType,
			["SetCode11ChecksumTypeRequested"] = MapSetCode11ChecksumType,
			["SetCode39ChecksumTypeRequested"] = MapSetCode39ChecksumType,
			["SetEncodingCharacterSetRequested"] = MapSetEncodingCharacterSet,
			["SetARHeaderTextFormatRequested"] = MapSetARHeaderTextFormat,
			["SetDatamatrixDpmModeEnabledRequested"] = MapSetDatamatrixDpmModeEnabled,
			["SetIdDocumentMasterChecksumEnabledRequested"] = MapSetIdDocumentMasterChecksumEnabled,
			["SetQRDpmModeEnabledRequested"] = MapSetQRDpmModeEnabled,
			["SetQRMicroDpmModeEnabledRequested"] = MapSetQRMicroDpmModeEnabled,
			["SetScanningIndicatorAlwaysVisibleRequested"] = MapSetScanningIndicatorAlwaysVisibleEnabled,
			["SetScanningIndicatorLineWidthRequested"] = MapSetScanningIndicatorWidth,
			["SetScanningIndicatorColorHexRequested"] = MapSetScanningIndicatorColor,
			["SetScanningIndicatorAnimationModeRequested"] = MapSetScanningIndicatorAnimationMode,
			["SetUpcEanDeblurEnabledRequested"] = MapSetUpcEanDeblurEnabled,
			["SetEnableMisshaped1DEnabledRequested"] = MapSetEnableMisshaped1DEnabled,
			["SetBarcodeThumbnailOnResultEnabledRequested"] = MapSetBarcodeThumbnailOnResultEnabled,
			["SetMaximumResultsCountRequested"] = MapSetMaximumResultsCount,
			["SetARResultLimitRequested"] = MapSetARResultLimit,
			["SetResultDisappearanceDelayMsRequested"] = MapSetResultDisappearanceDelayMs,
			["SetARHeaderVerticalTextMarginRequested"] = MapSetARHeaderVerticalTextMargin,
			["SetARHeaderHorizontalTextMarginRequested"] = MapSetARHeaderHorizontalTextMargin,
			["SetARHeaderHeightRequested"] = MapSetARHeaderHeight,
			["SetARHeaderMaxTextHeightRequested"] = MapSetARHeaderMaxTextHeight,
			["SetARHeaderMinTextHeightRequested"] = MapSetARHeaderMinTextHeight,
			["SetDuplicatesDelayMsRequested"] = MapSetDuplicatesDelayMs,
			["SetBarcodeTypeEnabledRequested"] = MapSetBarcodeTypeEnabled,
			["SetEnableVINRestrictionsRequested"] = MapSetEnableVINRestrictions,
			["SetARDoubleTapToFreezeEnabledRequested"] = MapSetDoubleTapToFreezeEnabled,
			["SetThresholdBetweenDuplicatesScansRequested"] = MapSetThresholdBetweenDuplicatesScans,
			["SetEnableCompositeRequested"] = MapSetEnableComposite,
			["SetBarcodeTypeLengthRangeRequested"] = MapSetBarcodeTypeLengthRange,
			["ConfigureBarkoderRequested"] = MapConfigureBarkoder
		};

		protected override View CreatePlatformView()
		{
			Context context = base.Context;
			BKDView = new Com.Barkoder.BarkoderView(context);
			return (View)(object)BKDView;
		}

		public float GetCurrentZoomFactor()
		{
			return BKDView?.CurrentZoomFactor ?? (-1f);
		}

		private static void MapLicenseKey(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView == null)
			{
				return;
			}
			handler.BKDView.Config = new Com.Barkoder.BarkoderConfig(((View)handler.BKDView).Context, view.LicenseKey, null);
			IDictionary<string, string> licenseInfo = Com.Barkoder.Barkoder.LicenseInfo;
			if (licenseInfo == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> item in licenseInfo)
			{
				Console.WriteLine(item.Key + ": " + item.Value);
			}
		}

		private static void MapIsFlashAvailable(BarkoderViewHandler handler, BarkoderView view)
		{
		}

		private static void MapMaxZoomFactor(BarkoderViewHandler handler, BarkoderView view)
		{
		}

		private static void MapInitCameraProperties(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (handler.BKDView != null)
			{
				AndroidBarkoderView androidBarkoderView = new AndroidBarkoderView(handler.BKDView);
				androidBarkoderView.isFlashAvailable(delegate(bool flashAvailable)
				{
					view.IsFlashAvailable = flashAvailable;
				});
				androidBarkoderView.getMaxZoomFactor(delegate(float maxZoomFactor)
				{
					view.MaxZoomFactor = maxZoomFactor;
				});
			}
		}

		private static void MapRoiLineColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.RoiLineColorHex = Util.IntColorToHexColor(handler.BKDView.Config.RoiLineColor);
			}
		}

		private static void MapLocationLineColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.LocationLineColorHex = Util.IntColorToHexColor(handler.BKDView.Config.LocationLineColor);
			}
		}

		private static void MapARNonSelectedLocationLineColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARNonSelectedLocationLineColorHex = Util.IntColorToHexColor(handler.BKDView.Config.ArConfig.NonSelectedLocationColor);
			}
		}

		private static void MapARImageResultEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARImageResultEnabled = handler.BKDView.Config.ArConfig.ImageResultEnabled;
			}
		}

		private static void MapARBarcodeThumbnailOnResultEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARBarcodeThumbnailOnResultEnabled = handler.BKDView.Config.ArConfig.BarcodeThumbnailOnResult;
			}
		}

		private static void MapARSelectedLocationLineColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARSelectedLocationLineColorHex = Util.IntColorToHexColor(handler.BKDView.Config.ArConfig.SelectedLocationColor);
			}
		}

		private static void MapARSelectedHeaderTextColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARSelectedHeaderTextColorHex = Util.IntColorToHexColor(handler.BKDView.Config.ArConfig.HeaderTextColorSelected);
			}
		}

		private static void MapARNonSelectedHeaderTextColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARNonSelectedHeaderTextColorHex = Util.IntColorToHexColor(handler.BKDView.Config.ArConfig.HeaderTextColorNonSelected);
			}
		}

		private static void MapRoiOverlayBackgroundColorHex(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.RoiOverlayBackgroundColorHex = Util.IntColorToHexColor(handler.BKDView.Config.RoiOverlayBackgroundColor);
			}
		}

		private static void MapEncodingCharacterSet(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.EncodingCharacterSet = handler.BKDView.Config.DecoderConfig.EncodingCharacterSet;
			}
		}

		private static void MapARHeaderTextFormat(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARHeaderTextFormat = handler.BKDView.Config.ArConfig.HeaderTextFormat;
			}
		}

		private static void MapLocationLineWidth(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.LocationLineWidth = handler.BKDView.Config.LocationLineWidth;
			}
		}

		private static void MapARSelectedLocationLineWidth(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARSelectedLocationLineWidth = handler.BKDView.Config.ArConfig.SelectedLocationLineWidth * 1.1f;
			}
		}

		private static void MapARNonSelectedLocationLineWidth(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARNonSelectedLocationLineWidth = handler.BKDView.Config.ArConfig.NonSelectedLocationLineWidth * 1.1f;
			}
		}

		private static void MapARLocationTransitionSpeed(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARLocationTransitionSpeed = handler.BKDView.Config.ArConfig.LocationTransitionSpeed;
			}
		}

		private static void MapImageResultEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ImageResultEnabled = handler.BKDView.Config.ImageResultEnabled;
			}
		}

		private static void MapLocationInImageResultEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.LocationInImageResultEnabled = handler.BKDView.Config.LocationInImageResultEnabled;
			}
		}

		private static void MapLocationInPreviewEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.LocationInPreviewEnabled = handler.BKDView.Config.LocationInPreviewEnabled;
			}
		}

		private static void MapPinchToZoomEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.PinchToZoomEnabled = handler.BKDView.Config.PinchToZoomEnabled;
			}
		}

		private static void MapBeepOnSuccessEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.BeepOnSuccessEnabled = handler.BKDView.Config.BeepOnSuccessEnabled;
			}
		}

		private static void MapVibrateOnSuccessEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.VibrateOnSuccessEnabled = handler.BKDView.Config.VibrateOnSuccessEnabled;
			}
		}

		private static void MapCloseSessionOnResultEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.CloseSessionOnResultEnabled = handler.BKDView.Config.CloseSessionOnResultEnabled;
			}
		}

		private static void MapARContinueScanningOnLimit(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.ARContinueScanningOnLimit = handler.BKDView.Config.ArConfig.ContinueScanningOnLimit;
			}
		}

		private static void MapAREmitResultsAtSessionEndOnly(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.AREmitResultsAtSessionEndOnly = handler.BKDView.Config.ArConfig.EmitResultsAtSessionEndOnly;
			}
		}

		private static void MapVersion(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.Version = Com.Barkoder.Barkoder.Version;
			}
		}

		private static void MapLibVersion(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				view.LibVersion = Com.Barkoder.Barkoder.LibVersion;
			}
		}

		public static void MapSetCustomOption(BarkoderViewHandler handler, BarkoderView view, object? argument)
		{
			if (handler.BKDView != null && argument is (string, int) tuple)
			{
				var (p, p2) = tuple;
				Com.Barkoder.Barkoder.SetCustomOption(handler.BKDView.Config.DecoderConfig, p, p2);
			}
		}

		private static void MapBarkoderResolution(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Enums.BarkoderResolution barkoderResolution = handler.BKDView.Config.BarkoderResolution;
				if (barkoderResolution == Com.Barkoder.Enums.BarkoderResolution.Hd)
				{
					view.BarkoderResolution = Plugin.Maui.Barkoder.Enums.BarkoderResolution.HD;
				}
				else if (barkoderResolution == Com.Barkoder.Enums.BarkoderResolution.Fhd)
				{
					view.BarkoderResolution = Plugin.Maui.Barkoder.Enums.BarkoderResolution.FHD;
				}
				else if (barkoderResolution == Com.Barkoder.Enums.BarkoderResolution.Uhd)
				{
					view.BarkoderResolution = Plugin.Maui.Barkoder.Enums.BarkoderResolution.UHD;
				}
			}
		}

		private static void MapBarkoderARMode(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Enums.BarkoderARMode aRMode = handler.BKDView.Config.ArConfig.ARMode;
				if (aRMode == Com.Barkoder.Enums.BarkoderARMode.Off)
				{
					view.BarkoderARMode = Plugin.Maui.Barkoder.Enums.BarkoderARMode.OFF;
				}
				else if (aRMode == Com.Barkoder.Enums.BarkoderARMode.InteractiveDisabled)
				{
					view.BarkoderARMode = Plugin.Maui.Barkoder.Enums.BarkoderARMode.InteractiveDisabled;
				}
				else if (aRMode == Com.Barkoder.Enums.BarkoderARMode.InteractiveEnabled)
				{
					view.BarkoderARMode = Plugin.Maui.Barkoder.Enums.BarkoderARMode.InteractiveEnabled;
				}
				else if (aRMode == Com.Barkoder.Enums.BarkoderARMode.NonInteractive)
				{
					view.BarkoderARMode = Plugin.Maui.Barkoder.Enums.BarkoderARMode.NonInteractive;
				}
			}
		}

		private static void MapBarkoderARHeaderShowMode(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Enums.BarkoderARHeaderShowMode headerShowMode = handler.BKDView.Config.ArConfig.HeaderShowMode;
				if (headerShowMode == Com.Barkoder.Enums.BarkoderARHeaderShowMode.Never)
				{
					view.BarkoderARHeaderShowMode = Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.NEVER;
				}
				else if (headerShowMode == Com.Barkoder.Enums.BarkoderARHeaderShowMode.Onselected)
				{
					view.BarkoderARHeaderShowMode = Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.ONSELECTED;
				}
				else if (headerShowMode == Com.Barkoder.Enums.BarkoderARHeaderShowMode.Always)
				{
					view.BarkoderARHeaderShowMode = Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.ALWAYS;
				}
			}
		}

		private static void MapBarkoderARLocationType(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Enums.BarkoderARLocationType locationType = handler.BKDView.Config.ArConfig.LocationType;
				if (locationType == Com.Barkoder.Enums.BarkoderARLocationType.None)
				{
					view.BarkoderARLocationType = Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.NONE;
				}
				else if (locationType == Com.Barkoder.Enums.BarkoderARLocationType.Tight)
				{
					view.BarkoderARLocationType = Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.TIGHT;
				}
				else if (locationType == Com.Barkoder.Enums.BarkoderARLocationType.Boundingbox)
				{
					view.BarkoderARLocationType = Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.BOUNDINGBOX;
				}
			}
		}

		private static void MapDecodingSpeed(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Barkoder.DecodingSpeed decodingSpeed = handler.BKDView.Config.DecoderConfig.DecodingSpeed;
				if (decodingSpeed == Com.Barkoder.Barkoder.DecodingSpeed.Slow)
				{
					view.DecodingSpeed = DecodingSpeed.Slow;
				}
				else if (decodingSpeed == Com.Barkoder.Barkoder.DecodingSpeed.Normal)
				{
					view.DecodingSpeed = DecodingSpeed.Normal;
				}
				else if (decodingSpeed == Com.Barkoder.Barkoder.DecodingSpeed.Fast)
				{
					view.DecodingSpeed = DecodingSpeed.Fast;
				}
				else if (decodingSpeed == Com.Barkoder.Barkoder.DecodingSpeed.Rigorous)
				{
					view.DecodingSpeed = DecodingSpeed.Rigorous;
				}
			}
		}

		private static void MapFormattingType(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Barkoder.FormattingType formattingType = handler.BKDView.Config.DecoderConfig.FormattingType;
				if (formattingType == Com.Barkoder.Barkoder.FormattingType.Aamva)
				{
					view.FormattingType = FormattingType.AAMVA;
				}
				else if (formattingType == Com.Barkoder.Barkoder.FormattingType.Automatic)
				{
					view.FormattingType = FormattingType.Automatic;
				}
				else if (formattingType == Com.Barkoder.Barkoder.FormattingType.Disabled)
				{
					view.FormattingType = FormattingType.Disabled;
				}
				else if (formattingType == Com.Barkoder.Barkoder.FormattingType.Gs1)
				{
					view.FormattingType = FormattingType.GS1;
				}
				else if (formattingType == Com.Barkoder.Barkoder.FormattingType.Sadl)
				{
					view.FormattingType = FormattingType.SADL;
				}
			}
		}

		private static void MapCode39ChecksumType(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Barkoder.Code39ChecksumType checksumType = handler.BKDView.Config.DecoderConfig.Code39.ChecksumType;
				if (checksumType == Com.Barkoder.Barkoder.Code39ChecksumType.Disabled)
				{
					view.Code39ChecksumType = Code39ChecksumType.Disabled;
				}
				else if (checksumType == Com.Barkoder.Barkoder.Code39ChecksumType.Enabled)
				{
					view.Code39ChecksumType = Code39ChecksumType.Enabled;
				}
			}
		}

		private static void MapCode11ChecksumType(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Barkoder.Code11ChecksumType checksumType = handler.BKDView.Config.DecoderConfig.Code11.ChecksumType;
				if (checksumType == Com.Barkoder.Barkoder.Code11ChecksumType.Disabled)
				{
					view.Code11ChecksumType = Code11ChecksumType.Disabled;
				}
				else if (checksumType == Com.Barkoder.Barkoder.Code11ChecksumType.Double)
				{
					view.Code11ChecksumType = Code11ChecksumType.Double;
				}
				else if (checksumType == Com.Barkoder.Barkoder.Code11ChecksumType.Single)
				{
					view.Code11ChecksumType = Code11ChecksumType.Single;
				}
			}
		}

		private static void MapMsiChecksumType(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Barkoder.MsiChecksumType checksumType = handler.BKDView.Config.DecoderConfig.Msi.ChecksumType;
				if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Disabled)
				{
					view.MsiChecksumType = MsiChecksumType.Disabled;
				}
				else if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Mod10)
				{
					view.MsiChecksumType = MsiChecksumType.Mod10;
				}
				else if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Mod11)
				{
					view.MsiChecksumType = MsiChecksumType.Mod11;
				}
				else if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Mod1010)
				{
					view.MsiChecksumType = MsiChecksumType.Mod1010;
				}
				else if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Mod1110)
				{
					view.MsiChecksumType = MsiChecksumType.Mod1110;
				}
				else if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Mod1110IBM)
				{
					view.MsiChecksumType = MsiChecksumType.Mod1110IBM;
				}
				else if (checksumType == Com.Barkoder.Barkoder.MsiChecksumType.Mod11IBM)
				{
					view.MsiChecksumType = MsiChecksumType.Mod11IBM;
				}
			}
		}

		private static void MapIdDocumentMasterChecksumEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				if (handler.BKDView.Config.DecoderConfig.IDDocument.MasterChecksumType == Com.Barkoder.Barkoder.StandardChecksumType.Enabled)
				{
					view.IdDocumentMasterCheckSumEnabled = true;
				}
				else
				{
					view.IdDocumentMasterCheckSumEnabled = false;
				}
			}
		}

		private static void MapDatamatrixDpmModeEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.DatamatrixDpmModeEnabled = handler.BKDView.Config.DecoderConfig.Datamatrix.DpmMode;
			}
		}

		private static void MapQRDpmModeEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.QRDpmModeEnabled = handler.BKDView.Config.DecoderConfig.Qr.DpmMode;
			}
		}

		private static void MapQRMicroDpmModeEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.QRMIcroDpmModeEnabled = handler.BKDView.Config.DecoderConfig.QRMicro.DpmMode;
			}
		}

		private static void MapUpcEanDeblurEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.UpcEanDeblurEnabled = handler.BKDView.Config.DecoderConfig.UpcEanDeblur;
			}
		}

		private static void MapEnableMisshaped1DEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.EnableMisshaped1DEnabled = handler.BKDView.Config.DecoderConfig.EnableMisshaped1D;
			}
		}

		private static void MapBarcodeThumbnailOnResultEnabledProperty(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.BarcodeThumbnailOnResultEnabled = handler.BKDView.Config.ThumbnailOnResulEnabled;
			}
		}

		private static void MapMaximumResultsCount(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.MaximumResultsCount = handler.BKDView.Config.DecoderConfig.MaximumResultsCount;
			}
		}

		private static void MapARResultLimit(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ARResultLimit = handler.BKDView.Config.ArConfig.ResultLimit;
			}
		}

		private static void MapResultDisappearanceDelayMs(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ResultDisappearanceDelayMs = handler.BKDView.Config.ArConfig.ResultDisappearanceDelayMs;
			}
		}

		private static void MapARHeaderVerticalTextMargin(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.HeaderARVerticalTextMargin = handler.BKDView.Config.ArConfig.HeaderVerticalTextMargin;
			}
		}

		private static void MapARHeaderHorizontalTextMargin(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.HeaderARHorizontalTextMargin = handler.BKDView.Config.ArConfig.HeaderHorizontalTextMargin;
			}
		}

		private static void MapARHeaderHeight(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ARHeaderHeight = handler.BKDView.Config.ArConfig.HeaderHeight;
			}
		}

		private static void MapARHeaderMaxTextHeight(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ARHeaderMaxTextHeight = handler.BKDView.Config.ArConfig.HeaderMaxTextHeight;
			}
		}

		private static void MapARHeaderMinTextHeight(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ARHeaderMinTextHeight = handler.BKDView.Config.ArConfig.HeaderMinTextHeight;
			}
		}

		private static void MapDuplicatesDelayMs(BarkoderViewHandler handler, BarkoderView view)
		{
		}

		private static void MapScanningIndicatorAlwaysVisibleEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ScanningIndicatorAlwaysVisibleEnabled = handler.BKDView.Config.ScanningIndicatorAlwaysVisible;
			}
		}

		private static void MapScanningIndicatorAnimationMode(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ScanningIndicatorAnimationMode = handler.BKDView.Config.ScanningIndicatorAnimation;
			}
		}

		private static void MapScanningIndicatorColor(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ScanningIndicatorLineColorHex = Util.IntColorToHexColor(handler.BKDView.Config.ScanningIndicatorColor);
			}
		}

		private static void MapScanningIndicatorWidth(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ScanningIndicatorLineWidth = handler.BKDView.Config.ScanningIndicatorWidth;
			}
		}

		private static void MapEnableComposite(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.EnableComposite = handler.BKDView.Config.DecoderConfig.EnableComposite;
			}
		}

		private static void MapMulticodeCachingDuration(BarkoderViewHandler handler, BarkoderView view)
		{
		}

		private static void MapVINRestrictionsEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.VINRestrictionsEnabled = handler.BKDView.Config.DecoderConfig.EnableVINRestrictions;
			}
		}

		private static void MapARDoubleTapToFreezeEnabled(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ARDoubleTapToFreezeEnabled = handler.BKDView.Config.ArConfig.DoubleTapToFreezeEnabled;
			}
		}

		private static void MapThresholdBetweenDuplicatesScans(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				view.ThresholdBetweenDuplicatesScans = handler.BKDView.Config.ThresholdBetweenDuplicatesScans;
			}
		}

		private static void MapRegionOfInterest(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null && handler.BKDView.Config != null)
			{
				Com.Barkoder.Barkoder.BKRect regionOfInterest = handler.BKDView.Config.RegionOfInterest;
				view.RegionOfInterest = ((int)regionOfInterest.Left, (int)regionOfInterest.Top, (int)regionOfInterest.Height, (int)regionOfInterest.Width);
			}
		}

		private static void MapStartCamera(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.StartCamera();
		}

		private static void MapStartScanning(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is IBarkoderDelegate barkoderDelegate && handler.BKDView != null)
			{
				new AndroidBarkoderView(barkoderDelegate, handler.BKDView).StartScanning();
			}
		}

		private static void MapScanImage(BarkoderViewHandler handler, BarkoderView view, object? arg)
		{
			string text = ((dynamic)arg).base64Image;
			IBarkoderDelegate barkoderDelegate = ((dynamic)arg).barkoderDelegate;
			if (handler.BKDView != null && !string.IsNullOrEmpty(text))
			{
				byte[] array = Convert.FromBase64String(text);
				Bitmap bitmap;
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					bitmap = BitmapFactory.DecodeStream((Stream)memoryStream);
				}
				bitmap = ApplyExifRotationIfNeeded(bitmap, array);
				Context context = ((ViewHandler<BarkoderView, View>)(object)handler).Context;
				new AndroidBarkoderView(barkoderDelegate, handler.BKDView).ScanImage(bitmap, handler.BKDView.Config, context);
			}
		}

		private static Bitmap RotateBitmap(Bitmap bitmap, float degrees)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			Matrix val = new Matrix();
			val.PostRotate(degrees);
			Bitmap result = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height, val, true);
			bitmap.Recycle();
			return result;
		}

		private static Bitmap ApplyExifRotationIfNeeded(Bitmap bitmap, byte[] imageBytes)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				using MemoryStream memoryStream = new MemoryStream(imageBytes);
				return (Bitmap)(new ExifInterface((Stream)memoryStream).GetAttributeInt("Orientation", 1) switch
				{
					6 => RotateBitmap(bitmap, 90f), 
					3 => RotateBitmap(bitmap, 180f), 
					8 => RotateBitmap(bitmap, 270f), 
					_ => bitmap, 
				});
			}
			catch
			{
				return bitmap;
			}
		}

		private static void MapStopScanning(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.StopScanning();
		}

		private static void MapSelectVisibleBarcodes(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.SelectVisibleBarcodes();
		}

		private static void MapConfigureCloseButton(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Expected O, but got Unknown
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Expected O, but got Unknown
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Expected O, but got Unknown
			if (handler?.BKDView != null && arg3 != null)
			{
				Type type = arg3.GetType();
				bool p = Convert.ToBoolean(type.GetProperty("visible")?.GetValue(arg3));
				object obj = type.GetProperty("position")?.GetValue(arg3);
				float[] p2 = ((!(obj is float[] array)) ? ((!(obj is IEnumerable<object> source)) ? Array.Empty<float>() : source.Select((object x) => Convert.ToSingle(x)).ToArray()) : array);
				float p3 = Convert.ToSingle(type.GetProperty("iconSize")?.GetValue(arg3));
				string text = type.GetProperty("tintColor")?.GetValue(arg3) as string;
				string text2 = type.GetProperty("backgroundColor")?.GetValue(arg3) as string;
				float p4 = Convert.ToSingle(type.GetProperty("cornerRadius")?.GetValue(arg3));
				float p5 = Convert.ToSingle(type.GetProperty("padding")?.GetValue(arg3));
				bool p6 = Convert.ToBoolean(type.GetProperty("useCustomIcon")?.GetValue(arg3));
				string @base = type.GetProperty("customIconBase64")?.GetValue(arg3) as string;
				Action onClose = type.GetProperty("onClose")?.GetValue(arg3) as Action;
				Integer p7 = null;
				if (HasColor(text))
				{
					p7 = new Integer(Util.HexColorToIntColor(text));
				}
				Integer p8 = null;
				if (HasColor(text2))
				{
					p8 = new Integer(Util.HexColorToIntColor(text2));
				}
				Bitmap p9 = DecodeBase64ToBitmap(@base);
				handler.BKDView.ConfigureCloseButton(p, p2, p3, p7, p8, p4, p5, p6, p9, (IRunnable)new Runnable((Action)delegate
				{
					onClose?.Invoke();
				}));
			}
			static bool HasColor(string? hex)
			{
				return !string.IsNullOrWhiteSpace(hex);
			}
		}

		private static void MapConfigureFlashButton(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Expected O, but got Unknown
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Expected O, but got Unknown
			if (handler?.BKDView != null && arg3 != null)
			{
				Type type = arg3.GetType();
				bool p = Convert.ToBoolean(type.GetProperty("visible")?.GetValue(arg3));
				object obj = type.GetProperty("position")?.GetValue(arg3);
				float[] p2 = ((!(obj is float[] array)) ? ((!(obj is IEnumerable<object> source)) ? Array.Empty<float>() : source.Select((object x) => Convert.ToSingle(x)).ToArray()) : array);
				float p3 = Convert.ToSingle(type.GetProperty("iconSize")?.GetValue(arg3));
				string text = type.GetProperty("tintColor")?.GetValue(arg3) as string;
				string text2 = type.GetProperty("backgroundColor")?.GetValue(arg3) as string;
				float p4 = Convert.ToSingle(type.GetProperty("cornerRadius")?.GetValue(arg3));
				float p5 = Convert.ToSingle(type.GetProperty("padding")?.GetValue(arg3));
				bool p6 = Convert.ToBoolean(type.GetProperty("useCustomIcon")?.GetValue(arg3));
				string @base = type.GetProperty("customIconFlashOnBase64")?.GetValue(arg3) as string;
				string base2 = type.GetProperty("customIconFlashOffBase64")?.GetValue(arg3) as string;
				Integer p7 = null;
				if (HasColor(text))
				{
					p7 = new Integer(Util.HexColorToIntColor(text));
				}
				Integer p8 = null;
				if (HasColor(text2))
				{
					p8 = new Integer(Util.HexColorToIntColor(text2));
				}
				Bitmap p9 = DecodeBase64ToBitmap(@base);
				Bitmap p10 = DecodeBase64ToBitmap(base2);
				handler.BKDView.ConfigureFlashButton(p, p2, p3, p7, p8, p4, p5, p6, p9, p10);
			}
			static bool HasColor(string? hex)
			{
				return !string.IsNullOrWhiteSpace(hex);
			}
		}

		private static void MapConfigureZoomButton(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Expected O, but got Unknown
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Expected O, but got Unknown
			if (handler?.BKDView != null && arg3 != null)
			{
				Type type = arg3.GetType();
				Convert.ToBoolean(type.GetProperty("visible")?.GetValue(arg3));
				object obj = type.GetProperty("position")?.GetValue(arg3);
				float[] p = ((!(obj is float[] array)) ? ((!(obj is IEnumerable<object> source)) ? Array.Empty<float>() : source.Select((object x) => Convert.ToSingle(x)).ToArray()) : array);
				float p2 = Convert.ToSingle(type.GetProperty("iconSize")?.GetValue(arg3));
				string text = type.GetProperty("tintColor")?.GetValue(arg3) as string;
				string text2 = type.GetProperty("backgroundColor")?.GetValue(arg3) as string;
				float p3 = Convert.ToSingle(type.GetProperty("cornerRadius")?.GetValue(arg3));
				float p4 = Convert.ToSingle(type.GetProperty("padding")?.GetValue(arg3));
				bool p5 = Convert.ToBoolean(type.GetProperty("useCustomIcon")?.GetValue(arg3));
				string @base = type.GetProperty("customIconZoomedInBase64")?.GetValue(arg3) as string;
				string base2 = type.GetProperty("customIconZoomedOutBase64")?.GetValue(arg3) as string;
				float p6 = Convert.ToSingle(type.GetProperty("zoomedInFactor")?.GetValue(arg3));
				float p7 = Convert.ToSingle(type.GetProperty("zoomedOutFactor")?.GetValue(arg3));
				Bitmap p8 = DecodeBase64ToBitmap(@base);
				Bitmap p9 = DecodeBase64ToBitmap(base2);
				Integer p10 = null;
				if (HasColor(text))
				{
					p10 = new Integer(Util.HexColorToIntColor(text));
				}
				Integer p11 = null;
				if (HasColor(text2))
				{
					p11 = new Integer(Util.HexColorToIntColor(text2));
				}
				handler.BKDView.ConfigureZoomButton(p0: true, p, p2, p10, p11, p3, p4, p5, p8, p9, p6, p7);
			}
			static bool HasColor(string? hex)
			{
				return !string.IsNullOrWhiteSpace(hex);
			}
		}

		public static int HexColorToIntColor2(string? hex)
		{
			if (string.IsNullOrWhiteSpace(hex))
			{
				return -1;
			}
			hex = hex.TrimStart('#');
			if (uint.TryParse(hex, NumberStyles.HexNumber, null, out var result))
			{
				if (hex.Length == 6)
				{
					return (int)result | -16777216;
				}
				return (int)result;
			}
			return -1;
		}

		private static void MapCaptureImage(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.CaptureImage();
		}

		private static void MapPauseScanning(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.PauseScanning();
		}

		private static void MapFreezeScanning(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.FreezeScanning();
		}

		private static void MapUnfreezeScanning(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			handler.BKDView?.UnfreezeScanning();
		}

		private static void MapRegionOfInterestVisible(BarkoderViewHandler handler, BarkoderView view)
		{
			if (handler.BKDView != null)
			{
				handler.BKDView.Config.RegionOfInterestVisible = true;
			}
		}

		private static void MapFlashEnable(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool flashEnabled)
			{
				handler.BKDView?.SetFlashEnabled(flashEnabled);
			}
		}

		private static void MapSetZoomFactor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is float zoomFactor)
			{
				handler.BKDView?.SetZoomFactor(zoomFactor);
			}
		}

		private static void MapSetPinchToZoomEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool pinchToZoomEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.PinchToZoomEnabled = pinchToZoomEnabled;
			}
		}

		private static void MapSetRegionOfInterestVisible(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool regionOfInterestVisible && handler.BKDView != null)
			{
				handler.BKDView.Config.RegionOfInterestVisible = regionOfInterestVisible;
			}
		}

		private static void MapSetRoiLineWidth(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is float roiLineWidth && handler.BKDView != null)
			{
				handler.BKDView.Config.RoiLineWidth = roiLineWidth;
			}
		}

		private static void MapSetVibrateOnSuccessEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool vibrateOnSuccessEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.VibrateOnSuccessEnabled = vibrateOnSuccessEnabled;
			}
		}

		private static void MapSetBeepOnSuccessEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool beepOnSuccessEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.BeepOnSuccessEnabled = beepOnSuccessEnabled;
			}
		}

		private static void MapSetLocationInImageResultEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool locationInImageResultEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.LocationInImageResultEnabled = locationInImageResultEnabled;
			}
		}

		private static Color? ParseHexColor(string? hex)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrWhiteSpace(hex))
			{
				return null;
			}
			try
			{
				if (!hex.StartsWith("#"))
				{
					hex = "#" + hex;
				}
				return Color.ParseColor(hex);
			}
			catch
			{
				return null;
			}
		}

		private static Bitmap? DecodeBase64ToBitmap(string base64)
		{
			if (string.IsNullOrWhiteSpace(base64))
			{
				return null;
			}
			try
			{
				byte[] array = Convert.FromBase64String(base64);
				return BitmapFactory.DecodeByteArray(array, 0, array.Length);
			}
			catch
			{
				return null;
			}
		}

		private static void MapSetLocationInPreviewEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool locationInPreviewEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.LocationInPreviewEnabled = locationInPreviewEnabled;
			}
		}

		private static void MapSetImageResultEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool imageResultEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.ImageResultEnabled = imageResultEnabled;
			}
		}

		private static void MapSetCloseSessionOnResult(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool closeSessionOnResultEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.CloseSessionOnResultEnabled = closeSessionOnResultEnabled;
			}
		}

		private static void MapSetARContinueScanningOnLimit(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool continueScanningOnLimit && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.ContinueScanningOnLimit = continueScanningOnLimit;
			}
		}

		private static void MapSetAREmitResultsAtSessionEndOnly(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool emitResultsAtSessionEndOnly && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.EmitResultsAtSessionEndOnly = emitResultsAtSessionEndOnly;
			}
		}

		private static void MapSetRoiLineColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.RoiLineColor = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetLocationLineColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.LocationLineColor = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetARNonSelectedLocationColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.NonSelectedLocationColor = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetARImageResultEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool imageResultEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.ImageResultEnabled = imageResultEnabled;
			}
		}

		private static void MapSetARBarcodeThumbnailOnResultEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool barcodeThumbnailOnResult && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.BarcodeThumbnailOnResult = barcodeThumbnailOnResult;
			}
		}

		private static void MapSetARSelectedLocationColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.SelectedLocationColor = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetARSelectedHeaderTextColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderTextColorSelected = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetARNonSelectedHeaderTextColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderTextColorNonSelected = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetARSelectedLocationLineWidth(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.SelectedLocationLineWidth = (float)num * 1.1f;
			}
		}

		private static void MapSetARNonSelectedLocationLineWidth(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.NonSelectedLocationLineWidth = (float)num * 1.1f;
			}
		}

		private static void MapSetARLocationTransitionSpeed(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.LocationTransitionSpeed = (float)num;
			}
		}

		private static void MapSetRoiOverlayBackgroundColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.RoiOverlayBackgroundColor = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetLocationLineWidth(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is float locationLineWidth && handler.BKDView != null)
			{
				handler.BKDView.Config.LocationLineWidth = locationLineWidth;
			}
		}

		private static void MapSetThreadsLimit(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
		}

		private static void MapSetRegionOfInterest(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int[] array && handler.BKDView != null)
			{
				try
				{
					handler.BKDView.Config.SetRegionOfInterest(array[0], array[1], array[2], array[3]);
				}
				catch
				{
				}
			}
		}

		private static void MapSetBarkoderResolution(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Plugin.Maui.Barkoder.Enums.BarkoderResolution barkoderResolution && handler.BKDView != null)
			{
				switch (barkoderResolution)
				{
				case Plugin.Maui.Barkoder.Enums.BarkoderResolution.FHD:
					handler.BKDView.Config.BarkoderResolution = Com.Barkoder.Enums.BarkoderResolution.Fhd;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderResolution.HD:
					handler.BKDView.Config.BarkoderResolution = Com.Barkoder.Enums.BarkoderResolution.Hd;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderResolution.UHD:
					handler.BKDView.Config.BarkoderResolution = Com.Barkoder.Enums.BarkoderResolution.Hd;
					break;
				}
			}
		}

		private static void MapSetBarkoderARMode(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Plugin.Maui.Barkoder.Enums.BarkoderARMode barkoderARMode && handler.BKDView != null)
			{
				switch (barkoderARMode)
				{
				case Plugin.Maui.Barkoder.Enums.BarkoderARMode.OFF:
					handler.BKDView.Config.ArConfig.ArMode = Com.Barkoder.Enums.BarkoderARMode.Off;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARMode.InteractiveDisabled:
					handler.BKDView.Config.ArConfig.ArMode = Com.Barkoder.Enums.BarkoderARMode.InteractiveDisabled;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARMode.InteractiveEnabled:
					handler.BKDView.Config.ArConfig.ArMode = Com.Barkoder.Enums.BarkoderARMode.InteractiveEnabled;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARMode.NonInteractive:
					handler.BKDView.Config.ArConfig.ArMode = Com.Barkoder.Enums.BarkoderARMode.NonInteractive;
					break;
				}
			}
		}

		private static void MapSetBarkoderARHeaderShowMode(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode barkoderARHeaderShowMode && handler.BKDView != null)
			{
				switch (barkoderARHeaderShowMode)
				{
				case Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.NEVER:
					handler.BKDView.Config.ArConfig.HeaderShowMode = Com.Barkoder.Enums.BarkoderARHeaderShowMode.Never;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.ONSELECTED:
					handler.BKDView.Config.ArConfig.HeaderShowMode = Com.Barkoder.Enums.BarkoderARHeaderShowMode.Onselected;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARHeaderShowMode.ALWAYS:
					handler.BKDView.Config.ArConfig.HeaderShowMode = Com.Barkoder.Enums.BarkoderARHeaderShowMode.Always;
					break;
				}
			}
		}

		private static void MapSetBarkoderARLocationType(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Plugin.Maui.Barkoder.Enums.BarkoderARLocationType barkoderARLocationType && handler.BKDView != null)
			{
				switch (barkoderARLocationType)
				{
				case Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.NONE:
					handler.BKDView.Config.ArConfig.LocationType = Com.Barkoder.Enums.BarkoderARLocationType.None;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.TIGHT:
					handler.BKDView.Config.ArConfig.LocationType = Com.Barkoder.Enums.BarkoderARLocationType.Tight;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderARLocationType.BOUNDINGBOX:
					handler.BKDView.Config.ArConfig.LocationType = Com.Barkoder.Enums.BarkoderARLocationType.Boundingbox;
					break;
				}
			}
		}

		private static void MapSetBarkoderARoverlayRefresh(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh barkoderAROverlayRefresh && handler.BKDView != null)
			{
				switch (barkoderAROverlayRefresh)
				{
				case Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh.NORMAL:
					handler.BKDView.Config.ArConfig.OverlayRefresh = Com.Barkoder.Overlaymanager.BarkoderAROverlayRefresh.Normal;
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderAROverlayRefresh.SMOOTH:
					handler.BKDView.Config.ArConfig.OverlayRefresh = Com.Barkoder.Overlaymanager.BarkoderAROverlayRefresh.Smooth;
					break;
				}
			}
		}

		private static void MapSetDecodingSpeed(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is DecodingSpeed decodingSpeed && handler.BKDView != null)
			{
				switch (decodingSpeed)
				{
				case DecodingSpeed.Slow:
					handler.BKDView.Config.DecoderConfig.DecodingSpeed = Com.Barkoder.Barkoder.DecodingSpeed.Slow;
					break;
				case DecodingSpeed.Normal:
					handler.BKDView.Config.DecoderConfig.DecodingSpeed = Com.Barkoder.Barkoder.DecodingSpeed.Normal;
					break;
				case DecodingSpeed.Fast:
					handler.BKDView.Config.DecoderConfig.DecodingSpeed = Com.Barkoder.Barkoder.DecodingSpeed.Fast;
					break;
				case DecodingSpeed.Rigorous:
					handler.BKDView.Config.DecoderConfig.DecodingSpeed = Com.Barkoder.Barkoder.DecodingSpeed.Rigorous;
					break;
				}
			}
		}

		private static void MapSetFormattingType(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is FormattingType formattingType && handler.BKDView != null)
			{
				switch (formattingType)
				{
				case FormattingType.Automatic:
					handler.BKDView.Config.DecoderConfig.FormattingType = Com.Barkoder.Barkoder.FormattingType.Automatic;
					break;
				case FormattingType.Disabled:
					handler.BKDView.Config.DecoderConfig.FormattingType = Com.Barkoder.Barkoder.FormattingType.Disabled;
					break;
				case FormattingType.AAMVA:
					handler.BKDView.Config.DecoderConfig.FormattingType = Com.Barkoder.Barkoder.FormattingType.Aamva;
					break;
				case FormattingType.GS1:
					handler.BKDView.Config.DecoderConfig.FormattingType = Com.Barkoder.Barkoder.FormattingType.Gs1;
					break;
				case FormattingType.SADL:
					handler.BKDView.Config.DecoderConfig.FormattingType = Com.Barkoder.Barkoder.FormattingType.Sadl;
					break;
				}
			}
		}

		private static void MapSetCode39ChecksumType(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Code39ChecksumType code39ChecksumType && handler.BKDView != null)
			{
				switch (code39ChecksumType)
				{
				case Code39ChecksumType.Disabled:
					handler.BKDView.Config.DecoderConfig.Code39.ChecksumType = Com.Barkoder.Barkoder.Code39ChecksumType.Disabled;
					break;
				case Code39ChecksumType.Enabled:
					handler.BKDView.Config.DecoderConfig.Code39.ChecksumType = Com.Barkoder.Barkoder.Code39ChecksumType.Enabled;
					break;
				}
			}
		}

		private static void MapSetCode11ChecksumType(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Code11ChecksumType code11ChecksumType && handler.BKDView != null)
			{
				switch (code11ChecksumType)
				{
				case Code11ChecksumType.Disabled:
					handler.BKDView.Config.DecoderConfig.Code11.ChecksumType = Com.Barkoder.Barkoder.Code11ChecksumType.Disabled;
					break;
				case Code11ChecksumType.Double:
					handler.BKDView.Config.DecoderConfig.Code11.ChecksumType = Com.Barkoder.Barkoder.Code11ChecksumType.Double;
					break;
				case Code11ChecksumType.Single:
					handler.BKDView.Config.DecoderConfig.Code11.ChecksumType = Com.Barkoder.Barkoder.Code11ChecksumType.Single;
					break;
				}
			}
		}

		private static void MapSetMsiChecksumType(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is MsiChecksumType msiChecksumType && handler.BKDView != null)
			{
				switch (msiChecksumType)
				{
				case MsiChecksumType.Disabled:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Disabled;
					break;
				case MsiChecksumType.Mod10:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Mod10;
					break;
				case MsiChecksumType.Mod1010:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Mod1010;
					break;
				case MsiChecksumType.Mod11:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Mod11;
					break;
				case MsiChecksumType.Mod1110:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Mod1110;
					break;
				case MsiChecksumType.Mod1110IBM:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Mod1110IBM;
					break;
				case MsiChecksumType.Mod11IBM:
					handler.BKDView.Config.DecoderConfig.Msi.ChecksumType = Com.Barkoder.Barkoder.MsiChecksumType.Mod11IBM;
					break;
				}
			}
		}

		private static void MapSetEncodingCharacterSet(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string encodingCharacterSet && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.EncodingCharacterSet = encodingCharacterSet;
			}
		}

		private static void MapSetARHeaderTextFormat(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string headerTextFormat && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderTextFormat = headerTextFormat;
			}
		}

		private static void MapSetIdDocumentMasterChecksumEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool flag && handler.BKDView != null)
			{
				if (flag)
				{
					handler.BKDView.Config.DecoderConfig.IDDocument.MasterChecksumType = Com.Barkoder.Barkoder.StandardChecksumType.Enabled;
				}
				else
				{
					handler.BKDView.Config.DecoderConfig.IDDocument.MasterChecksumType = Com.Barkoder.Barkoder.StandardChecksumType.Disabled;
				}
				view.IsIdDocumentMasterChecksumEnabled = flag;
			}
		}

		private static void MapSetDatamatrixDpmModeEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool flag && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.Datamatrix.DpmMode = flag;
				view.IsDatamatrixDpmModeEnabled = flag;
			}
		}

		private static void MapSetQRDpmModeEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool flag && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.Qr.DpmMode = flag;
				view.IsQRDpmModeEnabled = flag;
			}
		}

		private static void MapSetShowDuplicatesLocation(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool showDuplicatesLocations && handler.BKDView != null)
			{
				handler.BKDView.Config.ShowDuplicatesLocations = showDuplicatesLocations;
			}
		}

		private static void MapSetQRMicroDpmModeEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool flag && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.QRMicro.DpmMode = flag;
				view.IsQRMicroDpmModeEnabled = flag;
			}
		}

		private static void MapSetUpcEanDeblurEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool upcEanDeblur && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.UpcEanDeblur = upcEanDeblur;
			}
		}

		private static void MapSetEnableMisshaped1DEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool enableMisshaped1D && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.EnableMisshaped1D = enableMisshaped1D;
			}
		}

		private static void MapSetBarcodeThumbnailOnResultEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool thumbnailOnResultEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.SetThumbnailOnResultEnabled(thumbnailOnResultEnabled);
			}
		}

		private static void MapSetMaximumResultsCount(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int maximumResultsCount && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.MaximumResultsCount = maximumResultsCount;
			}
		}

		private static void MapSetARResultLimit(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int resultLimit && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.ResultLimit = resultLimit;
			}
		}

		private static void MapSetResultDisappearanceDelayMs(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int resultDisappearanceDelayMs && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.ResultDisappearanceDelayMs = resultDisappearanceDelayMs;
			}
		}

		private static void MapSetARHeaderVerticalTextMargin(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderVerticalTextMargin = (float)num;
			}
		}

		private static void MapSetARHeaderHorizontalTextMargin(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderHorizontalTextMargin = (float)num;
			}
		}

		private static void MapSetARHeaderHeight(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderHeight = (float)num;
			}
		}

		private static void MapSetARHeaderMaxTextHeight(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderMaxTextHeight = (float)num;
			}
		}

		private static void MapSetARHeaderMinTextHeight(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is double num && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.HeaderMinTextHeight = (float)num;
			}
		}

		private static void MapSetDuplicatesDelayMs(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int duplicatesDelayMs && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.DuplicatesDelayMs = duplicatesDelayMs;
			}
		}

		private static void MapSetScanningIndicatorAnimationMode(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int scanningIndicatorAnimation && handler.BKDView != null)
			{
				handler.BKDView.Config.ScanningIndicatorAnimation = scanningIndicatorAnimation;
			}
		}

		private static void MapSetDynamicExposure(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int dynamicExposure && handler.BKDView != null)
			{
				handler.BKDView.SetDynamicExposure(dynamicExposure);
			}
		}

		private static void MapSetCamera(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is Plugin.Maui.Barkoder.Enums.BarkoderCameraPosition barkoderCameraPosition && handler.BKDView != null)
			{
				switch (barkoderCameraPosition)
				{
				case Plugin.Maui.Barkoder.Enums.BarkoderCameraPosition.BACK:
					handler.BKDView.SetCamera(Com.Barkoder.Enums.BarkoderCameraPosition.Back);
					break;
				case Plugin.Maui.Barkoder.Enums.BarkoderCameraPosition.FRONT:
					handler.BKDView.SetCamera(Com.Barkoder.Enums.BarkoderCameraPosition.Front);
					break;
				}
			}
		}

		private static void MapSetScanningIndicatorAlwaysVisibleEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool scanningIndicatorAlwaysVisible && handler.BKDView != null)
			{
				handler.BKDView.Config.ScanningIndicatorAlwaysVisible = scanningIndicatorAlwaysVisible;
			}
		}

		private static void MapSetCentricFocusAndExposure(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool centricFocusAndExposure && handler.BKDView != null)
			{
				handler.BKDView.SetCentricFocusAndExposure(centricFocusAndExposure);
			}
		}

		private static void MapSetUPCE1expandToUPCA(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool expandToUPCA && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.UpcE1.ExpandToUPCA = expandToUPCA;
			}
		}

		private static void MapSetUPCEexpandToUPCA(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool expandToUPCA && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.UpcE.ExpandToUPCA = expandToUPCA;
			}
		}

		private static void MapSetVideoStabilization(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool videoStabilization && handler.BKDView != null)
			{
				handler.BKDView.SetVideoStabilization(videoStabilization);
			}
		}

		private static void MapSetScanningIndicatorColor(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is string hexColor && handler.BKDView != null)
			{
				handler.BKDView.Config.ScanningIndicatorColor = Util.HexColorToIntColor(hexColor);
			}
		}

		private static void MapSetScanningIndicatorWidth(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is float scanningIndicatorWidth && handler.BKDView != null)
			{
				handler.BKDView.Config.ScanningIndicatorWidth = scanningIndicatorWidth;
			}
		}

		private static void MapSetEnableComposite(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int enableComposite && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.EnableComposite = enableComposite;
			}
		}

		private static void MapSetMulticodeCachingDuration(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int)
			{
				_ = (int)arg3;
				_ = handler.BKDView;
			}
		}

		private static void MapSetBarcodeTypeEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is BarcodeTypeEventArgs e && handler.BKDView != null)
			{
				switch (e.BarcodeType)
				{
				case BarcodeType.Aztec:
					handler.BKDView.Config.DecoderConfig.Aztec.Enabled = e.Enabled;
					break;
				case BarcodeType.AztecCompact:
					handler.BKDView.Config.DecoderConfig.AztecCompact.Enabled = e.Enabled;
					break;
				case BarcodeType.QR:
					handler.BKDView.Config.DecoderConfig.Qr.Enabled = e.Enabled;
					break;
				case BarcodeType.QRMicro:
					handler.BKDView.Config.DecoderConfig.QRMicro.Enabled = e.Enabled;
					break;
				case BarcodeType.Code128:
					handler.BKDView.Config.DecoderConfig.Code128.Enabled = e.Enabled;
					break;
				case BarcodeType.Code93:
					handler.BKDView.Config.DecoderConfig.Code93.Enabled = e.Enabled;
					break;
				case BarcodeType.Code39:
					handler.BKDView.Config.DecoderConfig.Code39.Enabled = e.Enabled;
					break;
				case BarcodeType.Codabar:
					handler.BKDView.Config.DecoderConfig.Codabar.Enabled = e.Enabled;
					break;
				case BarcodeType.Code11:
					handler.BKDView.Config.DecoderConfig.Code11.Enabled = e.Enabled;
					break;
				case BarcodeType.Msi:
					handler.BKDView.Config.DecoderConfig.Msi.Enabled = e.Enabled;
					break;
				case BarcodeType.UpcA:
					handler.BKDView.Config.DecoderConfig.UpcA.Enabled = e.Enabled;
					break;
				case BarcodeType.UpcE:
					handler.BKDView.Config.DecoderConfig.UpcE.Enabled = e.Enabled;
					break;
				case BarcodeType.UpcE1:
					handler.BKDView.Config.DecoderConfig.UpcE1.Enabled = e.Enabled;
					break;
				case BarcodeType.Ean13:
					handler.BKDView.Config.DecoderConfig.Ean13.Enabled = e.Enabled;
					break;
				case BarcodeType.Ean8:
					handler.BKDView.Config.DecoderConfig.Ean8.Enabled = e.Enabled;
					break;
				case BarcodeType.PDF417:
					handler.BKDView.Config.DecoderConfig.Pdf417.Enabled = e.Enabled;
					break;
				case BarcodeType.PDF417Micro:
					handler.BKDView.Config.DecoderConfig.PDF417Micro.Enabled = e.Enabled;
					break;
				case BarcodeType.Datamatrix:
					handler.BKDView.Config.DecoderConfig.Datamatrix.Enabled = e.Enabled;
					break;
				case BarcodeType.Code25:
					handler.BKDView.Config.DecoderConfig.Code25.Enabled = e.Enabled;
					break;
				case BarcodeType.Interleaved25:
					handler.BKDView.Config.DecoderConfig.Interleaved25.Enabled = e.Enabled;
					break;
				case BarcodeType.Itf14:
					handler.BKDView.Config.DecoderConfig.Itf14.Enabled = e.Enabled;
					break;
				case BarcodeType.Matrix25:
					handler.BKDView.Config.DecoderConfig.Matrix25.Enabled = e.Enabled;
					break;
				case BarcodeType.Datalogic25:
					handler.BKDView.Config.DecoderConfig.Datalogic25.Enabled = e.Enabled;
					break;
				case BarcodeType.Coop25:
					handler.BKDView.Config.DecoderConfig.Coop25.Enabled = e.Enabled;
					break;
				case BarcodeType.Code32:
					handler.BKDView.Config.DecoderConfig.Code32.Enabled = e.Enabled;
					break;
				case BarcodeType.Telepen:
					handler.BKDView.Config.DecoderConfig.Telepen.Enabled = e.Enabled;
					break;
				case BarcodeType.Dotcode:
					handler.BKDView.Config.DecoderConfig.Dotcode.Enabled = e.Enabled;
					break;
				case BarcodeType.Maxicode:
					handler.BKDView.Config.DecoderConfig.MaxiCode.Enabled = e.Enabled;
					break;
				case BarcodeType.IDDocument:
					handler.BKDView.Config.DecoderConfig.IDDocument.Enabled = e.Enabled;
					break;
				case BarcodeType.Databar14:
					handler.BKDView.Config.DecoderConfig.Databar14.Enabled = e.Enabled;
					break;
				case BarcodeType.DatabarLimited:
					handler.BKDView.Config.DecoderConfig.DatabarLimited.Enabled = e.Enabled;
					break;
				case BarcodeType.DatabarExpanded:
					handler.BKDView.Config.DecoderConfig.DatabarExpanded.Enabled = e.Enabled;
					break;
				case BarcodeType.PostalIMB:
					handler.BKDView.Config.DecoderConfig.PostalIMB.Enabled = e.Enabled;
					break;
				case BarcodeType.Postnet:
					handler.BKDView.Config.DecoderConfig.Postnet.Enabled = e.Enabled;
					break;
				case BarcodeType.Planet:
					handler.BKDView.Config.DecoderConfig.Planet.Enabled = e.Enabled;
					break;
				case BarcodeType.AustralianPost:
					handler.BKDView.Config.DecoderConfig.AustralianPost.Enabled = e.Enabled;
					break;
				case BarcodeType.RoyalMail:
					handler.BKDView.Config.DecoderConfig.RoyalMail.Enabled = e.Enabled;
					break;
				case BarcodeType.KIX:
					handler.BKDView.Config.DecoderConfig.Kix.Enabled = e.Enabled;
					break;
				case BarcodeType.JapanesePost:
					handler.BKDView.Config.DecoderConfig.JapanesePost.Enabled = e.Enabled;
					break;
				case BarcodeType.OCRText:
					handler.BKDView.Config.DecoderConfig.OCRText.Enabled = e.Enabled;
					break;
				case BarcodeType.Uata25:
					break;
				}
			}
		}

		private static void MapSetEnableVINRestrictions(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool enableVINRestrictions && handler.BKDView != null)
			{
				handler.BKDView.Config.DecoderConfig.EnableVINRestrictions = enableVINRestrictions;
			}
		}

		private static void MapSetDoubleTapToFreezeEnabled(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is bool doubleTapToFreezeEnabled && handler.BKDView != null)
			{
				handler.BKDView.Config.ArConfig.DoubleTapToFreezeEnabled = doubleTapToFreezeEnabled;
			}
		}

		private static void MapSetThresholdBetweenDuplicatesScans(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is int thresholdBetweenDuplicatesScans && handler.BKDView != null)
			{
				handler.BKDView.Config.ThresholdBetweenDuplicatesScans = thresholdBetweenDuplicatesScans;
			}
		}

		private static void MapSetBarcodeTypeLengthRange(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			if (arg3 is BarcodeRangeEventArg barcodeRangeEventArg && handler.BKDView != null)
			{
				switch (barcodeRangeEventArg.BarcodeType)
				{
				case BarcodeType.Code128:
					handler.BKDView.Config.DecoderConfig.Code128.SetLengthRange(barcodeRangeEventArg.Min, barcodeRangeEventArg.Max);
					break;
				case BarcodeType.Code93:
					handler.BKDView.Config.DecoderConfig.Code93.SetLengthRange(barcodeRangeEventArg.Min, barcodeRangeEventArg.Max);
					break;
				case BarcodeType.Code39:
					handler.BKDView.Config.DecoderConfig.Code39.SetLengthRange(barcodeRangeEventArg.Min, barcodeRangeEventArg.Max);
					break;
				case BarcodeType.Codabar:
					handler.BKDView.Config.DecoderConfig.Codabar.SetLengthRange(barcodeRangeEventArg.Min, barcodeRangeEventArg.Max);
					break;
				case BarcodeType.Code11:
					handler.BKDView.Config.DecoderConfig.Code11.SetLengthRange(barcodeRangeEventArg.Min, barcodeRangeEventArg.Max);
					break;
				case BarcodeType.Msi:
					handler.BKDView.Config.DecoderConfig.Msi.SetLengthRange(barcodeRangeEventArg.Min, barcodeRangeEventArg.Max);
					break;
				}
			}
		}

		private static void MapConfigureBarkoder(BarkoderViewHandler handler, BarkoderView view, object? arg3)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			if (arg3 is string text && handler.BKDView != null)
			{
				dynamic val = (dynamic)new JSONObject(text);
				BarkoderHelper.ApplyJsonToConfig(handler.BKDView.Config, val);
			}
		}

		public BarkoderViewHandler()
			: base((IPropertyMapper)(object)PropertyMapper, (CommandMapper)(object)CommandMapper)
		{
		}
	}
	public class Util
	{
		public static int HexColorToIntColor(string hexColor)
		{
			if (hexColor.StartsWith("#"))
			{
				return ColorTranslator.FromHtml(hexColor).ToArgb();
			}
			return ColorTranslator.FromHtml("#" + hexColor).ToArgb();
		}

		public static string IntColorToHexColor(int intColor)
		{
			Color c = Color.FromArgb(intColor);
			return "#" + ColorTranslator.ToHtml(c).Substring(1);
		}
	}
	public class AndroidBarkoderView : AppCompatActivity, IBarkoderResultCallback, IJavaObject, IDisposable, IJavaPeerable, IFlashAvailableCallback, IMaxZoomAvailableCallback
	{
		public class SimpleKeyValue
		{
			public string Key { get; set; }

			public string Value { get; set; }
		}

		private IBarkoderDelegate? BarkoderDelegate;

		private Com.Barkoder.BarkoderView BkdView;

		private Action<bool>? flashAvailableCompletion;

		private Action<float>? maxZoomFactorCompletion;

		public AndroidBarkoderView(Com.Barkoder.BarkoderView bkdView)
		{
			BkdView = bkdView;
		}

		public AndroidBarkoderView(IBarkoderDelegate barkoderDelegate, Com.Barkoder.BarkoderView bkdView)
		{
			BarkoderDelegate = barkoderDelegate;
			BkdView = bkdView;
		}

		public void ScanImage(Bitmap bitmap, Com.Barkoder.BarkoderConfig config, Context context)
		{
			BarkoderHelper.ScanImage(bitmap, config, this, context);
		}

		public void StartScanning()
		{
			BkdView.StartScanning(this);
		}

		public void ScanningFinished(Com.Barkoder.Barkoder.Result[] result, Bitmap[] bitmaps, Bitmap originalImage)
		{
			BarcodeResult[] array = new BarcodeResult[result.Length];
			for (int i = 0; i < result.Length; i++)
			{
				List<ImageData> list = new List<ImageData>();
				Com.Barkoder.Barkoder.Result result2 = result[i];
				Dictionary<string, object> dictionary = null;
				if (result2.Extra != null && result2.Extra.Any())
				{
					dictionary = new Dictionary<string, object>();
					foreach (Com.Barkoder.Barkoder.BKKeyValue item in result2.Extra)
					{
						if (!string.IsNullOrEmpty(item.Key))
						{
							dictionary[item.Key] = item.Value ?? string.Empty;
						}
					}
				}
				if (result2.Images != null)
				{
					foreach (Com.Barkoder.Barkoder.BKImageDescriptor image3 in result2.Images)
					{
						if (image3.Image != null)
						{
							ImageSource val = BitmapToImageSource(image3.Image);
							if (val != null)
							{
								list.Add(new ImageData(image3.Name, val));
							}
						}
					}
				}
				string binaryDataAsBase = ((result2.BinaryData != null) ? Convert.ToBase64String(result2.BinaryData.ToArray()) : string.Empty);
				Bitmap bitmap = BarkoderHelper.SadlImage(result2.Extra?.ToArray() ?? Array.Empty<Com.Barkoder.Barkoder.BKKeyValue>());
				string sadlImageAsBase = SadlImageToBase64(bitmap);
				BarcodeResult barcodeResult = new BarcodeResult(result2.TextualData, result2.BarcodeTypeName, dictionary, "", list, ConvertLocation(result2), binaryDataAsBase, sadlImageAsBase);
				array[i] = barcodeResult;
			}
			ImageSource[] thumbnails = (from b in bitmaps?.Where((Bitmap b) => b != null)
				select BitmapToImageSource(b) into src
				where src != null
				select src).Cast<ImageSource>().ToArray() ?? Array.Empty<ImageSource>();
			ImageSource originalImageSource = BitmapToImageSource(originalImage);
			try
			{
			}
			finally
			{
				if (result != null)
				{
					foreach (Com.Barkoder.Barkoder.Result result3 in result)
					{
						if (result3?.Images != null)
						{
							foreach (Com.Barkoder.Barkoder.BKImageDescriptor image4 in result3.Images)
							{
								if (image4 != null)
								{
									Bitmap image = image4.Image;
									if (image != null)
									{
										image.Recycle();
									}
								}
								if (image4 != null)
								{
									Bitmap image2 = image4.Image;
									if (image2 != null)
									{
										((Object)image2).Dispose();
									}
								}
								if (image4 != null)
								{
									((Object)image4).Dispose();
								}
							}
						}
						if (result3 != null)
						{
							((Object)result3).Dispose();
						}
					}
				}
				if (bitmaps != null)
				{
					foreach (Bitmap obj in bitmaps)
					{
						if (obj != null)
						{
							obj.Recycle();
						}
						if (obj != null)
						{
							((Object)obj).Dispose();
						}
					}
				}
				if (originalImage != null)
				{
					originalImage.Recycle();
				}
				if (originalImage != null)
				{
					((Object)originalImage).Dispose();
				}
			}
			BarkoderDelegate?.DidFinishScanning(array, thumbnails, originalImageSource);
		}

		private string SadlImageToBase64(Bitmap bitmap)
		{
			if (bitmap == null)
			{
				return "";
			}
			using MemoryStream memoryStream = new MemoryStream();
			bitmap.Compress(CompressFormat.Png, 100, (Stream)memoryStream);
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		private BarcodeLocation ConvertLocation(Com.Barkoder.Barkoder.Result res)
		{
			if (res.Location == null)
			{
				return null;
			}
			return new BarcodeLocation
			{
				LocationName = res.Location.LocationName,
				Points = (res.Location.Points?.Select((Com.Barkoder.Barkoder.BKPoint p) => new BarcodePoint(p.X, p.Y)).ToList() ?? new List<BarcodePoint>())
			};
		}

		public void isFlashAvailable(Action<bool> completion)
		{
			flashAvailableCompletion = completion;
			BkdView.IsFlashAvailable(this);
		}

		public void getMaxZoomFactor(Action<float> completion)
		{
			maxZoomFactorCompletion = completion;
			BkdView.GetMaxZoomFactor(this);
		}

		public void OnFlashAvailable(bool flashAvailable)
		{
			if (flashAvailableCompletion != null)
			{
				flashAvailableCompletion(flashAvailable);
			}
		}

		public void OnMaxZoomAvailable(float maxZoomFactor)
		{
			if (maxZoomFactorCompletion != null)
			{
				maxZoomFactorCompletion(maxZoomFactor);
			}
		}

		private static ImageSource BitmapToImageSource(Bitmap bitmap)
		{
			if (bitmap == null || CompressFormat.Jpeg == null)
			{
				return ImageSource.FromStream((Func<Stream>)(() => new MemoryStream()));
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Compress(CompressFormat.Jpeg, 100, (Stream)memoryStream);
			byte[] buffer = Convert.FromBase64String(Convert.ToBase64String(memoryStream.ToArray()));
			MemoryStream imageSourceStream = new MemoryStream(buffer);
			return ImageSource.FromStream((Func<Stream>)(() => imageSourceStream));
		}
	}
}
namespace Plugin.Maui.Barkoder.Interfaces
{
	public interface IBarkoderDelegate
	{
		void DidFinishScanning(BarcodeResult[] result, ImageSource originalImageSource)
		{
		}

		void DidFinishScanning(BarcodeResult[] result, ImageSource[] thumbnails, ImageSource originalImageSource)
		{
			DidFinishScanning(result, originalImageSource);
		}
	}
}
namespace Plugin.Maui.Barkoder.Common
{
	public static class BarkoderGlobal
	{
		public static void SetCustomOptionGlobal(string option, int value)
		{
			SetCustomOptionGlobalPlatform(option, value);
		}

		private static void SetCustomOptionGlobalPlatform(string option, int value)
		{
			Com.Barkoder.Barkoder.SetCustomOptionGlobal(option, value);
		}
	}
}
namespace Plugin.Maui.Barkoder.Enums
{
	public enum BarcodeType
	{
		Aztec,
		AztecCompact,
		QR,
		QRMicro,
		Code128,
		Code93,
		Code39,
		Codabar,
		Code11,
		Msi,
		UpcA,
		UpcE,
		UpcE1,
		Ean13,
		Ean8,
		PDF417,
		PDF417Micro,
		Datamatrix,
		Code25,
		Interleaved25,
		Itf14,
		Uata25,
		Matrix25,
		Datalogic25,
		Coop25,
		Code32,
		Telepen,
		Dotcode,
		IDDocument,
		Databar14,
		DatabarLimited,
		DatabarExpanded,
		PostalIMB,
		Postnet,
		Planet,
		AustralianPost,
		RoyalMail,
		KIX,
		JapanesePost,
		Maxicode,
		OCRText
	}
	public enum BarkoderResolution
	{
		HD,
		FHD,
		UHD
	}
	public enum BarkoderARMode
	{
		OFF,
		InteractiveDisabled,
		InteractiveEnabled,
		NonInteractive
	}
	public enum BarkoderARHeaderShowMode
	{
		NEVER,
		ALWAYS,
		ONSELECTED
	}
	public enum BarkoderARLocationType
	{
		NONE,
		TIGHT,
		BOUNDINGBOX
	}
	public enum BarkoderAROverlayRefresh
	{
		SMOOTH,
		NORMAL
	}
	public enum Code11ChecksumType
	{
		Disabled,
		Single,
		Double
	}
	public enum BarkoderCameraPosition
	{
		BACK,
		FRONT
	}
	public enum Code39ChecksumType
	{
		Disabled,
		Enabled
	}
	public enum DecoderType
	{
		Aztec,
		AztecCompact,
		QR,
		QRMicro,
		Code128,
		Code93,
		Code39,
		Codabar,
		Code11,
		Msi,
		UpcA,
		UpcE,
		UpcE1,
		Ean13,
		Ean8,
		PDF417,
		PDF417Micro,
		Datamatrix,
		Code25,
		Interleaved25,
		Itf14,
		Uata25,
		Matrix25,
		Datalogic25,
		Coop25,
		Code32,
		Telepen,
		Dotcode,
		IDDocument,
		Databar14,
		DatabarLimited,
		DatabarExpanded,
		PostalIMB,
		Postnet,
		Planet,
		AustralianPost,
		RoyalMail,
		KIX,
		JapanesePost,
		Maxicode,
		OCRText
	}
	public enum DecodingSpeed
	{
		Fast,
		Normal,
		Slow,
		Rigorous
	}
	public enum FormattingType
	{
		Disabled,
		Automatic,
		GS1,
		AAMVA,
		SADL
	}
	public enum MsiChecksumType
	{
		Disabled,
		Mod10,
		Mod11,
		Mod1010,
		Mod1110,
		Mod11IBM,
		Mod1110IBM
	}
}
namespace Plugin.Maui.Barkoder.Handlers
{
	public class BarcodeResult
	{
		public string TextualData { get; set; }

		public string BarcodeTypeName { get; set; }

		public Dictionary<string, object>? Extra { get; set; }

		public string CharacterSet { get; set; }

		public List<ImageData> MrzImages { get; set; }

		public BarcodeLocation Location { get; set; }

		public string BinaryDataAsBase64 { get; set; }

		public string SadlImageAsBase64 { get; set; } = "";

		public BarcodeResult(string textualData, string barcodeTypeName, Dictionary<string, object>? extra, string characterSet, List<ImageData> mrzImages, BarcodeLocation location, string binaryDataAsBase64, string sadlImageAsBase64)
		{
			TextualData = textualData;
			BarcodeTypeName = barcodeTypeName;
			Extra = extra;
			CharacterSet = characterSet;
			MrzImages = mrzImages;
			Location = location;
			BinaryDataAsBase64 = binaryDataAsBase64;
			SadlImageAsBase64 = sadlImageAsBase64;
		}
	}
	public class ImageData
	{
		public string Name { get; set; }

		public ImageSource Image { get; set; }

		public ImageData(string name, ImageSource image)
		{
			Name = name;
			Image = image;
		}
	}
	public class BarcodeLocation
	{
		public List<BarcodePoint> Points { get; set; } = new List<BarcodePoint>();

		public string LocationName { get; set; }
	}
	public class BarcodePoint
	{
		public float X { get; set; }

		public float Y { get; set; }

		public BarcodePoint(float x, float y)
		{
			X = x;
			Y = y;
		}
	}
}
