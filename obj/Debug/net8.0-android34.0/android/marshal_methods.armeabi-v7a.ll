; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [329 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [658 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 20206211, ; 3: Xamarin.Google.MLKit.Vision.Interfaces.dll => 0x1345283 => 280
	i32 30793855, ; 4: Xamarin.Google.Android.ODML.Image.dll => 0x1d5e07f => 271
	i32 32687329, ; 5: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 232
	i32 34715100, ; 6: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 275
	i32 34839235, ; 7: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 9: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 10: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 11: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 327
	i32 68219467, ; 12: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 13: Microsoft.Maui.Graphics.dll => 0x44bb714 => 188
	i32 82292897, ; 14: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 15: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 250
	i32 103834273, ; 16: Xamarin.Firebase.Annotations.dll => 0x63062a1 => 262
	i32 117431740, ; 17: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 18: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 250
	i32 122350210, ; 19: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 20: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 290
	i32 142721839, ; 21: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 22: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 23: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 24: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 206
	i32 176265551, ; 25: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 26: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 252
	i32 184328833, ; 27: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 28: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 324
	i32 199333315, ; 29: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 325
	i32 205061960, ; 30: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 31: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 204
	i32 220171995, ; 32: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 33: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 226
	i32 230752869, ; 34: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 35: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 36: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 37: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 38: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 209
	i32 276479776, ; 39: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 40: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 228
	i32 280482487, ; 41: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 225
	i32 280992041, ; 42: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 296
	i32 291076382, ; 43: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 44: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 45: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 324
	i32 318968648, ; 46: Xamarin.AndroidX.Activity.dll => 0x13031348 => 195
	i32 321597661, ; 47: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 48: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 309
	i32 342366114, ; 49: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 227
	i32 356389973, ; 50: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 308
	i32 360082299, ; 51: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 52: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 53: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 54: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 55: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 56: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 57: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 58: _Microsoft.Android.Resource.Designer => 0x17969339 => 328
	i32 403441872, ; 59: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 60: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 320
	i32 441335492, ; 61: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 210
	i32 442565967, ; 62: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 63: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 223
	i32 451504562, ; 64: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 65: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 66: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 67: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 68: System.dll => 0x1bff388e => 164
	i32 476646585, ; 69: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 225
	i32 485140951, ; 70: Xamarin.Google.Android.DataTransport.TransportRuntime => 0x1ceaa9d7 => 269
	i32 486930444, ; 71: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 238
	i32 495452658, ; 72: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x1d8801f2 => 269
	i32 498788369, ; 73: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 74: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 307
	i32 503918385, ; 75: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 301
	i32 507148113, ; 76: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0x1e3a7751 => 267
	i32 507636436, ; 77: Xamarin.Google.MLKit.TextRecognition.Bundled.Common.dll => 0x1e41ead4 => 278
	i32 513247710, ; 78: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 182
	i32 513617146, ; 79: Xamarin.Google.MLKit.Vision.Common => 0x1e9d2cfa => 279
	i32 526420162, ; 80: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 81: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 290
	i32 530272170, ; 82: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 83: Microsoft.Extensions.Logging => 0x20216150 => 178
	i32 540030774, ; 84: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 85: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 86: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 87: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 88: Jsr305Binding => 0x213954e7 => 272
	i32 569601784, ; 89: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 261
	i32 577335427, ; 90: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 91: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 315
	i32 601371474, ; 92: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 93: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 94: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 95: Xamarin.AndroidX.CustomView => 0x2568904f => 215
	i32 627931235, ; 96: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 313
	i32 639843206, ; 97: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 221
	i32 643868501, ; 98: System.Net => 0x2660a755 => 81
	i32 662205335, ; 99: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 100: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 257
	i32 666292255, ; 101: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 202
	i32 672442732, ; 102: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 103: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 104: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 295
	i32 690569205, ; 105: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 106: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 292
	i32 693804605, ; 107: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 108: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 109: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 287
	i32 700358131, ; 110: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 111: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 310
	i32 709557578, ; 112: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 298
	i32 720511267, ; 113: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 291
	i32 722857257, ; 114: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 724243965, ; 115: _TmpMaui => 0x2b2b15fd => 0
	i32 735137430, ; 116: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 117: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 118: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 192
	i32 759454413, ; 119: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 120: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 121: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 122: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 319
	i32 789151979, ; 123: Microsoft.Extensions.Options => 0x2f0980eb => 181
	i32 790371945, ; 124: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 216
	i32 804715423, ; 125: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 126: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 230
	i32 823281589, ; 127: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 128: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 129: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 130: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 131: Xamarin.AndroidX.Print => 0x3246f6cd => 243
	i32 873119928, ; 132: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 133: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 134: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 135: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 136: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 926902833, ; 137: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 322
	i32 928116545, ; 138: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 275
	i32 952186615, ; 139: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 140: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 291
	i32 966729478, ; 141: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 273
	i32 967690846, ; 142: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 227
	i32 975236339, ; 143: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 144: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 145: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 146: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 147: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 148: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 996733531, ; 149: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3b68f25b => 268
	i32 1001831731, ; 150: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 151: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 247
	i32 1019214401, ; 152: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 153: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 177
	i32 1029334545, ; 154: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 297
	i32 1031528504, ; 155: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 274
	i32 1035644815, ; 156: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 200
	i32 1036536393, ; 157: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 158: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 159: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 234
	i32 1067306892, ; 160: GoogleGson => 0x3f9dcf8c => 173
	i32 1072034413, ; 161: BarkoderBindingMauiAndroid => 0x3fe5f26d => 189
	i32 1082857460, ; 162: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 163: Xamarin.Kotlin.StdLib => 0x409e66d8 => 288
	i32 1098259244, ; 164: System => 0x41761b2c => 164
	i32 1118262833, ; 165: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 310
	i32 1121599056, ; 166: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 233
	i32 1122050967, ; 167: Xamarin.Google.Android.ODML.Image => 0x42e12397 => 271
	i32 1127624469, ; 168: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 180
	i32 1149092582, ; 169: Xamarin.AndroidX.Window => 0x447dc2e6 => 260
	i32 1168523401, ; 170: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 316
	i32 1170634674, ; 171: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 172: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 256
	i32 1178241025, ; 173: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 241
	i32 1203215381, ; 174: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 314
	i32 1203469131, ; 175: Xamarin.Google.MLKit.Common.dll => 0x47bb7b4b => 276
	i32 1204270330, ; 176: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 202
	i32 1208641965, ; 177: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 178: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 179: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 312
	i32 1243150071, ; 180: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 261
	i32 1253011324, ; 181: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 182: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 296
	i32 1264511973, ; 183: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 251
	i32 1267360935, ; 184: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 255
	i32 1273260888, ; 185: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 207
	i32 1275534314, ; 186: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 292
	i32 1278448581, ; 187: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 199
	i32 1293217323, ; 188: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 218
	i32 1309188875, ; 189: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 190: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 260
	i32 1324164729, ; 191: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 192: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 193: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 194: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 326
	i32 1376866003, ; 195: Xamarin.AndroidX.SavedState => 0x52114ed3 => 247
	i32 1379779777, ; 196: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1379897097, ; 197: Xamarin.JavaX.Inject => 0x523f8f09 => 286
	i32 1398783858, ; 198: Plugin.Maui.Barkoder.dll => 0x535fbf72 => 190
	i32 1402170036, ; 199: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 200: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 211
	i32 1408764838, ; 201: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 202: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 203: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 204: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 294
	i32 1434145427, ; 205: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 206: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 273
	i32 1439761251, ; 207: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 208: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 209: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 210: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 211: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 212: es\Microsoft.Maui.Controls.resources => 0x57152abe => 300
	i32 1461234159, ; 213: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 214: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462063465, ; 215: Xamarin.GooglePlayServices.MLKit.Text.Recognition.Common.dll => 0x57255169 => 284
	i32 1462112819, ; 216: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 217: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 201
	i32 1470490898, ; 218: Microsoft.Extensions.Primitives => 0x57a5e912 => 182
	i32 1479771757, ; 219: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 220: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 221: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 222: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 248
	i32 1493001747, ; 223: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 304
	i32 1514721132, ; 224: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 299
	i32 1536373174, ; 225: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 226: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 227: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 228: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 229: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 319
	i32 1565862583, ; 230: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 231: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 232: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 233: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 234: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 217
	i32 1592978981, ; 235: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 236: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 274
	i32 1601112923, ; 237: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 238: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 239: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 240: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 237
	i32 1622358360, ; 241: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 242: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 259
	i32 1635184631, ; 243: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 221
	i32 1636350590, ; 244: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 214
	i32 1639515021, ; 245: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 246: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 247: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 248: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 249: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 253
	i32 1658251792, ; 250: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 270
	i32 1670060433, ; 251: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 209
	i32 1675553242, ; 252: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 253: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 254: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 255: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 256: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 257: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 258: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 289
	i32 1701541528, ; 259: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 260: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 230
	i32 1726116996, ; 261: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 262: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 263: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 205
	i32 1736233607, ; 264: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 317
	i32 1743415430, ; 265: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 295
	i32 1744735666, ; 266: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 267: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 268: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 269: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 270: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 271: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 272: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 252
	i32 1770582343, ; 273: Microsoft.Extensions.Logging.dll => 0x6988f147 => 178
	i32 1776026572, ; 274: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 275: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 276: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 277: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 311
	i32 1788241197, ; 278: Xamarin.AndroidX.Fragment => 0x6a96652d => 223
	i32 1793755602, ; 279: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 303
	i32 1808609942, ; 280: Xamarin.AndroidX.Loader => 0x6bcd3296 => 237
	i32 1813058853, ; 281: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 288
	i32 1813201214, ; 282: Xamarin.Google.Android.Material => 0x6c13413e => 270
	i32 1818569960, ; 283: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 242
	i32 1818787751, ; 284: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 285: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 286: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 287: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 179
	i32 1842015223, ; 288: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 323
	i32 1847515442, ; 289: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 192
	i32 1853025655, ; 290: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 320
	i32 1858542181, ; 291: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 292: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 293: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 302
	i32 1876173635, ; 294: Xamarin.Firebase.Encoders.Proto => 0x6fd42343 => 266
	i32 1879696579, ; 295: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 296: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 203
	i32 1888955245, ; 297: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 298: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 299: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 300: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1908813208, ; 301: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 282
	i32 1910275211, ; 302: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 303: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 304: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 305: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 249
	i32 1968388702, ; 306: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 174
	i32 1983156543, ; 307: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 289
	i32 1985761444, ; 308: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 194
	i32 2003115576, ; 309: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 299
	i32 2011961780, ; 310: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 311: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 234
	i32 2025202353, ; 312: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 294
	i32 2031763787, ; 313: Xamarin.Android.Glide => 0x791a414b => 191
	i32 2045470958, ; 314: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 315: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 229
	i32 2060060697, ; 316: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 317: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 298
	i32 2070888862, ; 318: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 319: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 320: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2124230737, ; 321: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x7e9d3051 => 268
	i32 2127167465, ; 322: System.Console => 0x7ec9ffe9 => 20
	i32 2129483829, ; 323: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 281
	i32 2142473426, ; 324: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 325: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 326: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 327: Microsoft.Maui => 0x80bd55ad => 186
	i32 2169148018, ; 328: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 306
	i32 2174878672, ; 329: Xamarin.Firebase.Annotations => 0x81a203d0 => 262
	i32 2181898931, ; 330: Microsoft.Extensions.Options.dll => 0x820d22b3 => 181
	i32 2192057212, ; 331: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 179
	i32 2193016926, ; 332: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 333: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 293
	i32 2201231467, ; 334: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 335: it\Microsoft.Maui.Controls.resources => 0x839595db => 308
	i32 2217644978, ; 336: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 256
	i32 2222056684, ; 337: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 338: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 238
	i32 2252106437, ; 339: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 340: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 341: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 342: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 175
	i32 2267999099, ; 343: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 193
	i32 2270573516, ; 344: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 302
	i32 2279755925, ; 345: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 245
	i32 2293034957, ; 346: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 347: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 348: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 349: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 312
	i32 2305521784, ; 350: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 351: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 197
	i32 2320631194, ; 352: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 353: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 354: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 355: System.Net.Primitives => 0x8c40e0db => 70
	i32 2365655487, ; 356: Xamarin.GooglePlayServices.MLKit.Text.Recognition.Common => 0x8d0109bf => 284
	i32 2368005991, ; 357: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 358: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 174
	i32 2378619854, ; 359: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 360: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 361: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 307
	i32 2401565422, ; 362: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 363: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 220
	i32 2421380589, ; 364: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 365: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 207
	i32 2427813419, ; 366: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 304
	i32 2435356389, ; 367: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 368: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 369: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2457221118, ; 370: Xamarin.GooglePlayServices.MLKit.Text.Recognition.dll => 0x927637fe => 283
	i32 2458678730, ; 371: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 372: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 373: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 210
	i32 2471841756, ; 374: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 375: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 376: Microsoft.Maui.Controls => 0x93dba8a1 => 184
	i32 2483903535, ; 377: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 378: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 379: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 380: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 381: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 232
	i32 2522472828, ; 382: Xamarin.Android.Glide.dll => 0x9659e17c => 191
	i32 2538310050, ; 383: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 384: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 305
	i32 2562349572, ; 385: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2565628955, ; 386: Xamarin.GooglePlayServices.MLKit.Text.Recognition => 0x98ec641b => 283
	i32 2570120770, ; 387: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 388: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 233
	i32 2581819634, ; 389: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 255
	i32 2585220780, ; 390: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 391: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 392: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 393: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 314
	i32 2605712449, ; 394: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 293
	i32 2615233544, ; 395: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 224
	i32 2616218305, ; 396: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 180
	i32 2617129537, ; 397: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 398: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620111890, ; 399: Xamarin.Firebase.Encoders.dll => 0x9c2bbc12 => 264
	i32 2620871830, ; 400: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 214
	i32 2624644809, ; 401: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 219
	i32 2626831493, ; 402: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 309
	i32 2627185994, ; 403: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 404: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 405: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 228
	i32 2639764100, ; 406: Xamarin.Firebase.Encoders => 0x9d579a84 => 264
	i32 2663391936, ; 407: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 193
	i32 2663698177, ; 408: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 409: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 410: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 411: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 412: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 413: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 414: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 253
	i32 2715334215, ; 415: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 416: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 417: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 418: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 419: Xamarin.AndroidX.Activity => 0xa2e0939b => 195
	i32 2735172069, ; 420: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 421: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 201
	i32 2740948882, ; 422: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 423: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 424: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 315
	i32 2758225723, ; 425: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 185
	i32 2764765095, ; 426: Microsoft.Maui.dll => 0xa4caf7a7 => 186
	i32 2765824710, ; 427: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 428: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 287
	i32 2778768386, ; 429: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 258
	i32 2779977773, ; 430: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 246
	i32 2785988530, ; 431: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 321
	i32 2788224221, ; 432: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 224
	i32 2801831435, ; 433: Microsoft.Maui.Graphics => 0xa7008e0b => 188
	i32 2803228030, ; 434: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2804607052, ; 435: Xamarin.Firebase.Components.dll => 0xa72ae84c => 263
	i32 2806116107, ; 436: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 300
	i32 2810250172, ; 437: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 211
	i32 2819470561, ; 438: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 439: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 440: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 246
	i32 2824502124, ; 441: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 442: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 313
	i32 2838993487, ; 443: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 235
	i32 2847418871, ; 444: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 281
	i32 2849599387, ; 445: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 446: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 258
	i32 2855708567, ; 447: Xamarin.AndroidX.Transition => 0xaa36a797 => 254
	i32 2858015478, ; 448: Plugin.Maui.Barkoder => 0xaa59daf6 => 190
	i32 2861098320, ; 449: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 450: Microsoft.Maui.Essentials => 0xaa8a4878 => 187
	i32 2868099152, ; 451: Xamarin.Google.MLKit.Vision.Common.dll => 0xaaf3b850 => 279
	i32 2870099610, ; 452: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 196
	i32 2875164099, ; 453: Jsr305Binding.dll => 0xab5f85c3 => 272
	i32 2875220617, ; 454: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 455: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 222
	i32 2887636118, ; 456: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 457: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 458: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 459: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 460: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 461: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 462: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 259
	i32 2919462931, ; 463: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 464: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 198
	i32 2936416060, ; 465: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 466: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 467: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 468: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 469: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 470: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 471: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 218
	i32 2987532451, ; 472: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 249
	i32 2996846495, ; 473: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 231
	i32 3016983068, ; 474: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 251
	i32 3023353419, ; 475: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 476: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 226
	i32 3038032645, ; 477: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 328
	i32 3056245963, ; 478: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 248
	i32 3057625584, ; 479: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 239
	i32 3058099980, ; 480: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 285
	i32 3059408633, ; 481: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 482: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 483: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 484: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 306
	i32 3090735792, ; 485: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 486: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 487: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 488: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 489: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 490: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 491: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 492: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 493: GoogleGson.dll => 0xbba64c02 => 173
	i32 3155362983, ; 494: Xamarin.Google.Android.DataTransport.TransportApi => 0xbc1304a7 => 267
	i32 3159123045, ; 495: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 496: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 497: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 240
	i32 3192346100, ; 498: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 499: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 500: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 501: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 502: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 217
	i32 3220365878, ; 503: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 504: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3230466174, ; 505: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 282
	i32 3251039220, ; 506: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 507: Xamarin.AndroidX.CardView => 0xc235e84d => 205
	i32 3265493905, ; 508: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 509: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 510: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 511: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 512: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 513: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 514: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 515: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 516: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 301
	i32 3316684772, ; 517: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 518: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 215
	i32 3317144872, ; 519: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 520: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 203
	i32 3345895724, ; 521: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 244
	i32 3346324047, ; 522: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 241
	i32 3357674450, ; 523: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 318
	i32 3358260929, ; 524: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 525: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 196
	i32 3362522851, ; 526: Xamarin.AndroidX.Core => 0xc86c06e3 => 212
	i32 3366347497, ; 527: Java.Interop => 0xc8a662e9 => 168
	i32 3371992681, ; 528: Xamarin.Firebase.Encoders.Proto.dll => 0xc8fc8669 => 266
	i32 3374999561, ; 529: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 245
	i32 3381016424, ; 530: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 297
	i32 3383578424, ; 531: Xamarin.Firebase.Encoders.JSON => 0xc9ad4f38 => 265
	i32 3395150330, ; 532: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 533: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 534: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 216
	i32 3411362516, ; 535: Xamarin.Google.MLKit.Vision.Interfaces => 0xcb5542d4 => 280
	i32 3428513518, ; 536: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 176
	i32 3429136800, ; 537: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 538: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 539: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 219
	i32 3445260447, ; 540: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 541: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 183
	i32 3463511458, ; 542: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 305
	i32 3471940407, ; 543: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 544: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 545: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 318
	i32 3484440000, ; 546: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 317
	i32 3485117614, ; 547: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 548: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 549: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 208
	i32 3509114376, ; 550: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 551: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 552: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 553: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 554: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 555: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 556: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 325
	i32 3597029428, ; 557: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 194
	i32 3598340787, ; 558: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 559: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 560: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3626429363, ; 561: Xamarin.Google.MLKit.Common => 0xd826ebb3 => 276
	i32 3627220390, ; 562: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 243
	i32 3633644679, ; 563: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 198
	i32 3638274909, ; 564: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 565: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 229
	i32 3643446276, ; 566: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 322
	i32 3643854240, ; 567: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 240
	i32 3645089577, ; 568: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 569: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 175
	i32 3660523487, ; 570: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 571: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 572: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 204
	i32 3684561358, ; 573: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 208
	i32 3697841164, ; 574: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 327
	i32 3700866549, ; 575: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 576: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 213
	i32 3716563718, ; 577: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 578: Xamarin.AndroidX.Annotation => 0xdda814c6 => 197
	i32 3724971120, ; 579: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 239
	i32 3732100267, ; 580: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 581: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 582: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 583: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3758390674, ; 584: Xamarin.Google.MLKit.TextRecognition => 0xe0047d92 => 277
	i32 3786282454, ; 585: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 206
	i32 3792276235, ; 586: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 587: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 183
	i32 3802395368, ; 588: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 589: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 590: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 591: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 592: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 177
	i32 3843715963, ; 593: Xamarin.Google.MLKit.TextRecognition.dll => 0xe51a737b => 277
	i32 3844307129, ; 594: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 595: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 596: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 597: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 598: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 599: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 600: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 254
	i32 3888767677, ; 601: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 244
	i32 3889960447, ; 602: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 326
	i32 3896106733, ; 603: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 604: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 212
	i32 3901907137, ; 605: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 606: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 607: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 257
	i32 3928044579, ; 608: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 609: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 610: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 242
	i32 3934056515, ; 611: Xamarin.JavaX.Inject.dll => 0xea7cf043 => 286
	i32 3945713374, ; 612: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 613: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 614: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 200
	i32 3959773229, ; 615: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 231
	i32 3970018735, ; 616: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 285
	i32 3980434154, ; 617: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 321
	i32 3987592930, ; 618: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 303
	i32 4003436829, ; 619: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 620: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 199
	i32 4025784931, ; 621: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 622: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 185
	i32 4052947547, ; 623: Xamarin.Google.MLKit.TextRecognition.Bundled.Common => 0xf193125b => 278
	i32 4054681211, ; 624: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4054949490, ; 625: BarkoderBindingMauiAndroid.dll => 0xf1b19e72 => 189
	i32 4068434129, ; 626: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 627: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 628: Microsoft.Maui.Essentials.dll => 0xf40add04 => 187
	i32 4099507663, ; 629: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 630: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 631: Xamarin.AndroidX.Emoji2 => 0xf479582c => 220
	i32 4102112229, ; 632: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 316
	i32 4123387713, ; 633: _TmpMaui.dll => 0xf5c5e741 => 0
	i32 4125707920, ; 634: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 311
	i32 4126470640, ; 635: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 176
	i32 4127667938, ; 636: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 637: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 638: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 639: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 323
	i32 4151237749, ; 640: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 641: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 642: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 643: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 644: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 645: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 236
	i32 4185676441, ; 646: System.Security => 0xf97c5a99 => 130
	i32 4192648326, ; 647: Xamarin.Firebase.Encoders.JSON.dll => 0xf9e6bc86 => 265
	i32 4196529839, ; 648: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 649: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 650: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 213
	i32 4258378803, ; 651: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 235
	i32 4260525087, ; 652: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 653: Microsoft.Maui.Controls.dll => 0xfea12dee => 184
	i32 4274976490, ; 654: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4284549794, ; 655: Xamarin.Firebase.Components => 0xff610aa2 => 263
	i32 4292120959, ; 656: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 236
	i32 4294763496 ; 657: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 222
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [658 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 280, ; 3
	i32 271, ; 4
	i32 232, ; 5
	i32 275, ; 6
	i32 48, ; 7
	i32 80, ; 8
	i32 145, ; 9
	i32 30, ; 10
	i32 327, ; 11
	i32 124, ; 12
	i32 188, ; 13
	i32 102, ; 14
	i32 250, ; 15
	i32 262, ; 16
	i32 107, ; 17
	i32 250, ; 18
	i32 139, ; 19
	i32 290, ; 20
	i32 77, ; 21
	i32 124, ; 22
	i32 13, ; 23
	i32 206, ; 24
	i32 132, ; 25
	i32 252, ; 26
	i32 151, ; 27
	i32 324, ; 28
	i32 325, ; 29
	i32 18, ; 30
	i32 204, ; 31
	i32 26, ; 32
	i32 226, ; 33
	i32 1, ; 34
	i32 59, ; 35
	i32 42, ; 36
	i32 91, ; 37
	i32 209, ; 38
	i32 147, ; 39
	i32 228, ; 40
	i32 225, ; 41
	i32 296, ; 42
	i32 54, ; 43
	i32 69, ; 44
	i32 324, ; 45
	i32 195, ; 46
	i32 83, ; 47
	i32 309, ; 48
	i32 227, ; 49
	i32 308, ; 50
	i32 131, ; 51
	i32 55, ; 52
	i32 149, ; 53
	i32 74, ; 54
	i32 145, ; 55
	i32 62, ; 56
	i32 146, ; 57
	i32 328, ; 58
	i32 165, ; 59
	i32 320, ; 60
	i32 210, ; 61
	i32 12, ; 62
	i32 223, ; 63
	i32 125, ; 64
	i32 152, ; 65
	i32 113, ; 66
	i32 166, ; 67
	i32 164, ; 68
	i32 225, ; 69
	i32 269, ; 70
	i32 238, ; 71
	i32 269, ; 72
	i32 84, ; 73
	i32 307, ; 74
	i32 301, ; 75
	i32 267, ; 76
	i32 278, ; 77
	i32 182, ; 78
	i32 279, ; 79
	i32 150, ; 80
	i32 290, ; 81
	i32 60, ; 82
	i32 178, ; 83
	i32 51, ; 84
	i32 103, ; 85
	i32 114, ; 86
	i32 40, ; 87
	i32 272, ; 88
	i32 261, ; 89
	i32 120, ; 90
	i32 315, ; 91
	i32 52, ; 92
	i32 44, ; 93
	i32 119, ; 94
	i32 215, ; 95
	i32 313, ; 96
	i32 221, ; 97
	i32 81, ; 98
	i32 136, ; 99
	i32 257, ; 100
	i32 202, ; 101
	i32 8, ; 102
	i32 73, ; 103
	i32 295, ; 104
	i32 155, ; 105
	i32 292, ; 106
	i32 154, ; 107
	i32 92, ; 108
	i32 287, ; 109
	i32 45, ; 110
	i32 310, ; 111
	i32 298, ; 112
	i32 291, ; 113
	i32 109, ; 114
	i32 0, ; 115
	i32 129, ; 116
	i32 25, ; 117
	i32 192, ; 118
	i32 72, ; 119
	i32 55, ; 120
	i32 46, ; 121
	i32 319, ; 122
	i32 181, ; 123
	i32 216, ; 124
	i32 22, ; 125
	i32 230, ; 126
	i32 86, ; 127
	i32 43, ; 128
	i32 160, ; 129
	i32 71, ; 130
	i32 243, ; 131
	i32 3, ; 132
	i32 42, ; 133
	i32 63, ; 134
	i32 16, ; 135
	i32 53, ; 136
	i32 322, ; 137
	i32 275, ; 138
	i32 105, ; 139
	i32 291, ; 140
	i32 273, ; 141
	i32 227, ; 142
	i32 34, ; 143
	i32 158, ; 144
	i32 85, ; 145
	i32 32, ; 146
	i32 12, ; 147
	i32 51, ; 148
	i32 268, ; 149
	i32 56, ; 150
	i32 247, ; 151
	i32 36, ; 152
	i32 177, ; 153
	i32 297, ; 154
	i32 274, ; 155
	i32 200, ; 156
	i32 35, ; 157
	i32 58, ; 158
	i32 234, ; 159
	i32 173, ; 160
	i32 189, ; 161
	i32 17, ; 162
	i32 288, ; 163
	i32 164, ; 164
	i32 310, ; 165
	i32 233, ; 166
	i32 271, ; 167
	i32 180, ; 168
	i32 260, ; 169
	i32 316, ; 170
	i32 153, ; 171
	i32 256, ; 172
	i32 241, ; 173
	i32 314, ; 174
	i32 276, ; 175
	i32 202, ; 176
	i32 29, ; 177
	i32 52, ; 178
	i32 312, ; 179
	i32 261, ; 180
	i32 5, ; 181
	i32 296, ; 182
	i32 251, ; 183
	i32 255, ; 184
	i32 207, ; 185
	i32 292, ; 186
	i32 199, ; 187
	i32 218, ; 188
	i32 85, ; 189
	i32 260, ; 190
	i32 61, ; 191
	i32 112, ; 192
	i32 57, ; 193
	i32 326, ; 194
	i32 247, ; 195
	i32 99, ; 196
	i32 286, ; 197
	i32 190, ; 198
	i32 19, ; 199
	i32 211, ; 200
	i32 111, ; 201
	i32 101, ; 202
	i32 102, ; 203
	i32 294, ; 204
	i32 104, ; 205
	i32 273, ; 206
	i32 71, ; 207
	i32 38, ; 208
	i32 32, ; 209
	i32 103, ; 210
	i32 73, ; 211
	i32 300, ; 212
	i32 9, ; 213
	i32 123, ; 214
	i32 284, ; 215
	i32 46, ; 216
	i32 201, ; 217
	i32 182, ; 218
	i32 9, ; 219
	i32 43, ; 220
	i32 4, ; 221
	i32 248, ; 222
	i32 304, ; 223
	i32 299, ; 224
	i32 31, ; 225
	i32 138, ; 226
	i32 92, ; 227
	i32 93, ; 228
	i32 319, ; 229
	i32 49, ; 230
	i32 141, ; 231
	i32 112, ; 232
	i32 140, ; 233
	i32 217, ; 234
	i32 115, ; 235
	i32 274, ; 236
	i32 157, ; 237
	i32 76, ; 238
	i32 79, ; 239
	i32 237, ; 240
	i32 37, ; 241
	i32 259, ; 242
	i32 221, ; 243
	i32 214, ; 244
	i32 64, ; 245
	i32 138, ; 246
	i32 15, ; 247
	i32 116, ; 248
	i32 253, ; 249
	i32 270, ; 250
	i32 209, ; 251
	i32 48, ; 252
	i32 70, ; 253
	i32 80, ; 254
	i32 126, ; 255
	i32 94, ; 256
	i32 121, ; 257
	i32 289, ; 258
	i32 26, ; 259
	i32 230, ; 260
	i32 97, ; 261
	i32 28, ; 262
	i32 205, ; 263
	i32 317, ; 264
	i32 295, ; 265
	i32 149, ; 266
	i32 169, ; 267
	i32 4, ; 268
	i32 98, ; 269
	i32 33, ; 270
	i32 93, ; 271
	i32 252, ; 272
	i32 178, ; 273
	i32 21, ; 274
	i32 41, ; 275
	i32 170, ; 276
	i32 311, ; 277
	i32 223, ; 278
	i32 303, ; 279
	i32 237, ; 280
	i32 288, ; 281
	i32 270, ; 282
	i32 242, ; 283
	i32 2, ; 284
	i32 134, ; 285
	i32 111, ; 286
	i32 179, ; 287
	i32 323, ; 288
	i32 192, ; 289
	i32 320, ; 290
	i32 58, ; 291
	i32 95, ; 292
	i32 302, ; 293
	i32 266, ; 294
	i32 39, ; 295
	i32 203, ; 296
	i32 25, ; 297
	i32 94, ; 298
	i32 89, ; 299
	i32 99, ; 300
	i32 282, ; 301
	i32 10, ; 302
	i32 87, ; 303
	i32 100, ; 304
	i32 249, ; 305
	i32 174, ; 306
	i32 289, ; 307
	i32 194, ; 308
	i32 299, ; 309
	i32 7, ; 310
	i32 234, ; 311
	i32 294, ; 312
	i32 191, ; 313
	i32 88, ; 314
	i32 229, ; 315
	i32 154, ; 316
	i32 298, ; 317
	i32 33, ; 318
	i32 116, ; 319
	i32 82, ; 320
	i32 268, ; 321
	i32 20, ; 322
	i32 281, ; 323
	i32 11, ; 324
	i32 162, ; 325
	i32 3, ; 326
	i32 186, ; 327
	i32 306, ; 328
	i32 262, ; 329
	i32 181, ; 330
	i32 179, ; 331
	i32 84, ; 332
	i32 293, ; 333
	i32 64, ; 334
	i32 308, ; 335
	i32 256, ; 336
	i32 143, ; 337
	i32 238, ; 338
	i32 157, ; 339
	i32 41, ; 340
	i32 117, ; 341
	i32 175, ; 342
	i32 193, ; 343
	i32 302, ; 344
	i32 245, ; 345
	i32 131, ; 346
	i32 75, ; 347
	i32 66, ; 348
	i32 312, ; 349
	i32 172, ; 350
	i32 197, ; 351
	i32 143, ; 352
	i32 106, ; 353
	i32 151, ; 354
	i32 70, ; 355
	i32 284, ; 356
	i32 156, ; 357
	i32 174, ; 358
	i32 121, ; 359
	i32 127, ; 360
	i32 307, ; 361
	i32 152, ; 362
	i32 220, ; 363
	i32 141, ; 364
	i32 207, ; 365
	i32 304, ; 366
	i32 20, ; 367
	i32 14, ; 368
	i32 135, ; 369
	i32 283, ; 370
	i32 75, ; 371
	i32 59, ; 372
	i32 210, ; 373
	i32 167, ; 374
	i32 168, ; 375
	i32 184, ; 376
	i32 15, ; 377
	i32 74, ; 378
	i32 6, ; 379
	i32 23, ; 380
	i32 232, ; 381
	i32 191, ; 382
	i32 91, ; 383
	i32 305, ; 384
	i32 1, ; 385
	i32 283, ; 386
	i32 136, ; 387
	i32 233, ; 388
	i32 255, ; 389
	i32 134, ; 390
	i32 69, ; 391
	i32 146, ; 392
	i32 314, ; 393
	i32 293, ; 394
	i32 224, ; 395
	i32 180, ; 396
	i32 88, ; 397
	i32 96, ; 398
	i32 264, ; 399
	i32 214, ; 400
	i32 219, ; 401
	i32 309, ; 402
	i32 31, ; 403
	i32 45, ; 404
	i32 228, ; 405
	i32 264, ; 406
	i32 193, ; 407
	i32 109, ; 408
	i32 158, ; 409
	i32 35, ; 410
	i32 22, ; 411
	i32 114, ; 412
	i32 57, ; 413
	i32 253, ; 414
	i32 144, ; 415
	i32 118, ; 416
	i32 120, ; 417
	i32 110, ; 418
	i32 195, ; 419
	i32 139, ; 420
	i32 201, ; 421
	i32 54, ; 422
	i32 105, ; 423
	i32 315, ; 424
	i32 185, ; 425
	i32 186, ; 426
	i32 133, ; 427
	i32 287, ; 428
	i32 258, ; 429
	i32 246, ; 430
	i32 321, ; 431
	i32 224, ; 432
	i32 188, ; 433
	i32 159, ; 434
	i32 263, ; 435
	i32 300, ; 436
	i32 211, ; 437
	i32 163, ; 438
	i32 132, ; 439
	i32 246, ; 440
	i32 161, ; 441
	i32 313, ; 442
	i32 235, ; 443
	i32 281, ; 444
	i32 140, ; 445
	i32 258, ; 446
	i32 254, ; 447
	i32 190, ; 448
	i32 169, ; 449
	i32 187, ; 450
	i32 279, ; 451
	i32 196, ; 452
	i32 272, ; 453
	i32 40, ; 454
	i32 222, ; 455
	i32 81, ; 456
	i32 56, ; 457
	i32 37, ; 458
	i32 97, ; 459
	i32 166, ; 460
	i32 172, ; 461
	i32 259, ; 462
	i32 82, ; 463
	i32 198, ; 464
	i32 98, ; 465
	i32 30, ; 466
	i32 159, ; 467
	i32 18, ; 468
	i32 127, ; 469
	i32 119, ; 470
	i32 218, ; 471
	i32 249, ; 472
	i32 231, ; 473
	i32 251, ; 474
	i32 165, ; 475
	i32 226, ; 476
	i32 328, ; 477
	i32 248, ; 478
	i32 239, ; 479
	i32 285, ; 480
	i32 170, ; 481
	i32 16, ; 482
	i32 144, ; 483
	i32 306, ; 484
	i32 125, ; 485
	i32 118, ; 486
	i32 38, ; 487
	i32 115, ; 488
	i32 47, ; 489
	i32 142, ; 490
	i32 117, ; 491
	i32 34, ; 492
	i32 173, ; 493
	i32 267, ; 494
	i32 95, ; 495
	i32 53, ; 496
	i32 240, ; 497
	i32 129, ; 498
	i32 153, ; 499
	i32 24, ; 500
	i32 161, ; 501
	i32 217, ; 502
	i32 148, ; 503
	i32 104, ; 504
	i32 282, ; 505
	i32 89, ; 506
	i32 205, ; 507
	i32 60, ; 508
	i32 142, ; 509
	i32 100, ; 510
	i32 5, ; 511
	i32 13, ; 512
	i32 122, ; 513
	i32 135, ; 514
	i32 28, ; 515
	i32 301, ; 516
	i32 72, ; 517
	i32 215, ; 518
	i32 24, ; 519
	i32 203, ; 520
	i32 244, ; 521
	i32 241, ; 522
	i32 318, ; 523
	i32 137, ; 524
	i32 196, ; 525
	i32 212, ; 526
	i32 168, ; 527
	i32 266, ; 528
	i32 245, ; 529
	i32 297, ; 530
	i32 265, ; 531
	i32 101, ; 532
	i32 123, ; 533
	i32 216, ; 534
	i32 280, ; 535
	i32 176, ; 536
	i32 163, ; 537
	i32 167, ; 538
	i32 219, ; 539
	i32 39, ; 540
	i32 183, ; 541
	i32 305, ; 542
	i32 17, ; 543
	i32 171, ; 544
	i32 318, ; 545
	i32 317, ; 546
	i32 137, ; 547
	i32 150, ; 548
	i32 208, ; 549
	i32 155, ; 550
	i32 130, ; 551
	i32 19, ; 552
	i32 65, ; 553
	i32 147, ; 554
	i32 47, ; 555
	i32 325, ; 556
	i32 194, ; 557
	i32 79, ; 558
	i32 61, ; 559
	i32 106, ; 560
	i32 276, ; 561
	i32 243, ; 562
	i32 198, ; 563
	i32 49, ; 564
	i32 229, ; 565
	i32 322, ; 566
	i32 240, ; 567
	i32 14, ; 568
	i32 175, ; 569
	i32 68, ; 570
	i32 171, ; 571
	i32 204, ; 572
	i32 208, ; 573
	i32 327, ; 574
	i32 78, ; 575
	i32 213, ; 576
	i32 108, ; 577
	i32 197, ; 578
	i32 239, ; 579
	i32 67, ; 580
	i32 63, ; 581
	i32 27, ; 582
	i32 160, ; 583
	i32 277, ; 584
	i32 206, ; 585
	i32 10, ; 586
	i32 183, ; 587
	i32 11, ; 588
	i32 78, ; 589
	i32 126, ; 590
	i32 83, ; 591
	i32 177, ; 592
	i32 277, ; 593
	i32 66, ; 594
	i32 107, ; 595
	i32 65, ; 596
	i32 128, ; 597
	i32 122, ; 598
	i32 77, ; 599
	i32 254, ; 600
	i32 244, ; 601
	i32 326, ; 602
	i32 8, ; 603
	i32 212, ; 604
	i32 2, ; 605
	i32 44, ; 606
	i32 257, ; 607
	i32 156, ; 608
	i32 128, ; 609
	i32 242, ; 610
	i32 286, ; 611
	i32 23, ; 612
	i32 133, ; 613
	i32 200, ; 614
	i32 231, ; 615
	i32 285, ; 616
	i32 321, ; 617
	i32 303, ; 618
	i32 29, ; 619
	i32 199, ; 620
	i32 62, ; 621
	i32 185, ; 622
	i32 278, ; 623
	i32 90, ; 624
	i32 189, ; 625
	i32 87, ; 626
	i32 148, ; 627
	i32 187, ; 628
	i32 36, ; 629
	i32 86, ; 630
	i32 220, ; 631
	i32 316, ; 632
	i32 0, ; 633
	i32 311, ; 634
	i32 176, ; 635
	i32 50, ; 636
	i32 6, ; 637
	i32 90, ; 638
	i32 323, ; 639
	i32 21, ; 640
	i32 162, ; 641
	i32 96, ; 642
	i32 50, ; 643
	i32 113, ; 644
	i32 236, ; 645
	i32 130, ; 646
	i32 265, ; 647
	i32 76, ; 648
	i32 27, ; 649
	i32 213, ; 650
	i32 235, ; 651
	i32 7, ; 652
	i32 184, ; 653
	i32 110, ; 654
	i32 263, ; 655
	i32 236, ; 656
	i32 222 ; 657
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 82d8938cf80f6d5fa6c28529ddfbdb753d805ab4"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
