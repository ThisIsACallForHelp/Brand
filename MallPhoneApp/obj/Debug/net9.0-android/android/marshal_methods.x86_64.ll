; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [320 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [960 x i64] [
	i64 u0x001e58127c546039, ; 0: lib_System.Globalization.dll.so => 42
	i64 u0x0024d0f62dee05bd, ; 1: Xamarin.KotlinX.Coroutines.Core.dll => 279
	i64 u0x0071cf2d27b7d61e, ; 2: lib_Xamarin.AndroidX.SwipeRefreshLayout.dll.so => 259
	i64 u0x01109b0e4d99e61f, ; 3: System.ComponentModel.Annotations.dll => 13
	i64 u0x02123411c4e01926, ; 4: lib_Xamarin.AndroidX.Navigation.Runtime.dll.so => 248
	i64 u0x0284512fad379f7e, ; 5: System.Runtime.Handles => 105
	i64 u0x02abedc11addc1ed, ; 6: lib_Mono.Android.Runtime.dll.so => 171
	i64 u0x02f55bf70672f5c8, ; 7: lib_System.IO.FileSystem.DriveInfo.dll.so => 48
	i64 u0x032267b2a94db371, ; 8: lib_Xamarin.AndroidX.AppCompat.dll.so => 202
	i64 u0x03621c804933a890, ; 9: System.Buffers => 7
	i64 u0x0399610510a38a38, ; 10: lib_System.Private.DataContractSerialization.dll.so => 86
	i64 u0x043032f1d071fae0, ; 11: ru/Microsoft.Maui.Controls.resources => 307
	i64 u0x044440a55165631e, ; 12: lib-cs-Microsoft.Maui.Controls.resources.dll.so => 285
	i64 u0x046eb1581a80c6b0, ; 13: vi/Microsoft.Maui.Controls.resources => 313
	i64 u0x047408741db2431a, ; 14: Xamarin.AndroidX.DynamicAnimation => 222
	i64 u0x0517ef04e06e9f76, ; 15: System.Net.Primitives => 71
	i64 u0x0565d18c6da3de38, ; 16: Xamarin.AndroidX.RecyclerView => 252
	i64 u0x0581db89237110e9, ; 17: lib_System.Collections.dll.so => 12
	i64 u0x05989cb940b225a9, ; 18: Microsoft.Maui.dll => 188
	i64 u0x05a1c25e78e22d87, ; 19: lib_System.Runtime.CompilerServices.Unsafe.dll.so => 102
	i64 u0x06076b5d2b581f08, ; 20: zh-HK/Microsoft.Maui.Controls.resources => 314
	i64 u0x06388ffe9f6c161a, ; 21: System.Xml.Linq.dll => 156
	i64 u0x06600c4c124cb358, ; 22: System.Configuration.dll => 19
	i64 u0x067f95c5ddab55b3, ; 23: lib_Xamarin.AndroidX.Fragment.Ktx.dll.so => 227
	i64 u0x0680a433c781bb3d, ; 24: Xamarin.AndroidX.Collection.Jvm => 209
	i64 u0x069fff96ec92a91d, ; 25: System.Xml.XPath.dll => 161
	i64 u0x070b0847e18dab68, ; 26: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 224
	i64 u0x0739448d84d3b016, ; 27: lib_Xamarin.AndroidX.VectorDrawable.dll.so => 262
	i64 u0x07469f2eecce9e85, ; 28: mscorlib.dll => 167
	i64 u0x07c57877c7ba78ad, ; 29: ru/Microsoft.Maui.Controls.resources.dll => 307
	i64 u0x07dcdc7460a0c5e4, ; 30: System.Collections.NonGeneric => 10
	i64 u0x08122e52765333c8, ; 31: lib_Microsoft.Extensions.Logging.Debug.dll.so => 183
	i64 u0x088610fc2509f69e, ; 32: lib_Xamarin.AndroidX.VectorDrawable.Animated.dll.so => 263
	i64 u0x08a7c865576bbde7, ; 33: System.Reflection.Primitives => 96
	i64 u0x08c9d051a4a817e5, ; 34: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 219
	i64 u0x08f3c9788ee2153c, ; 35: Xamarin.AndroidX.DrawerLayout => 221
	i64 u0x09138715c92dba90, ; 36: lib_System.ComponentModel.Annotations.dll.so => 13
	i64 u0x0919c28b89381a0b, ; 37: lib_Microsoft.Extensions.Options.dll.so => 184
	i64 u0x092266563089ae3e, ; 38: lib_System.Collections.NonGeneric.dll.so => 10
	i64 u0x09d144a7e214d457, ; 39: System.Security.Cryptography => 127
	i64 u0x09e2b9f743db21a8, ; 40: lib_System.Reflection.Metadata.dll.so => 95
	i64 u0x0abb3e2b271edc45, ; 41: System.Threading.Channels.dll => 140
	i64 u0x0b06b1feab070143, ; 42: System.Formats.Tar => 39
	i64 u0x0b3b632c3bbee20c, ; 43: sk/Microsoft.Maui.Controls.resources => 308
	i64 u0x0b6aff547b84fbe9, ; 44: Xamarin.KotlinX.Serialization.Core.Jvm => 282
	i64 u0x0be2e1f8ce4064ed, ; 45: Xamarin.AndroidX.ViewPager => 265
	i64 u0x0c3ca6cc978e2aae, ; 46: pt-BR/Microsoft.Maui.Controls.resources => 304
	i64 u0x0c59ad9fbbd43abe, ; 47: Mono.Android => 172
	i64 u0x0c65741e86371ee3, ; 48: lib_Xamarin.Android.Glide.GifDecoder.dll.so => 196
	i64 u0x0c74af560004e816, ; 49: Microsoft.Win32.Registry.dll => 5
	i64 u0x0c7790f60165fc06, ; 50: lib_Microsoft.Maui.Essentials.dll.so => 189
	i64 u0x0c83c82812e96127, ; 51: lib_System.Net.Mail.dll.so => 67
	i64 u0x0cce4bce83380b7f, ; 52: Xamarin.AndroidX.Security.SecurityCrypto => 256
	i64 u0x0d13cd7cce4284e4, ; 53: System.Security.SecureString => 130
	i64 u0x0d63f4f73521c24f, ; 54: lib_Xamarin.AndroidX.SavedState.SavedState.Ktx.dll.so => 255
	i64 u0x0e04e702012f8463, ; 55: Xamarin.AndroidX.Emoji2 => 223
	i64 u0x0e14e73a54dda68e, ; 56: lib_System.Net.NameResolution.dll.so => 68
	i64 u0x0f37dd7a62ae99af, ; 57: lib_Xamarin.AndroidX.Collection.Ktx.dll.so => 210
	i64 u0x0f5e7abaa7cf470a, ; 58: System.Net.HttpListener => 66
	i64 u0x1001f97bbe242e64, ; 59: System.IO.UnmanagedMemoryStream => 57
	i64 u0x102a31b45304b1da, ; 60: Xamarin.AndroidX.CustomView => 218
	i64 u0x1065c4cb554c3d75, ; 61: System.IO.IsolatedStorage.dll => 52
	i64 u0x10f6cfcbcf801616, ; 62: System.IO.Compression.Brotli => 43
	i64 u0x114443cdcf2091f1, ; 63: System.Security.Cryptography.Primitives => 125
	i64 u0x11a603952763e1d4, ; 64: System.Net.Mail => 67
	i64 u0x11a70d0e1009fb11, ; 65: System.Net.WebSockets.dll => 81
	i64 u0x11f26371eee0d3c1, ; 66: lib_Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll.so => 238
	i64 u0x12128b3f59302d47, ; 67: lib_System.Xml.Serialization.dll.so => 158
	i64 u0x123639456fb056da, ; 68: System.Reflection.Emit.Lightweight.dll => 92
	i64 u0x12521e9764603eaa, ; 69: lib_System.Resources.Reader.dll.so => 99
	i64 u0x125b7f94acb989db, ; 70: Xamarin.AndroidX.RecyclerView.dll => 252
	i64 u0x12d3b63863d4ab0b, ; 71: lib_System.Threading.Overlapped.dll.so => 141
	i64 u0x134eab1061c395ee, ; 72: System.Transactions => 151
	i64 u0x138567fa954faa55, ; 73: Xamarin.AndroidX.Browser => 206
	i64 u0x13a01de0cbc3f06c, ; 74: lib-fr-Microsoft.Maui.Controls.resources.dll.so => 291
	i64 u0x13beedefb0e28a45, ; 75: lib_System.Xml.XmlDocument.dll.so => 162
	i64 u0x13f1e5e209e91af4, ; 76: lib_Java.Interop.dll.so => 169
	i64 u0x13f1e880c25d96d1, ; 77: he/Microsoft.Maui.Controls.resources => 292
	i64 u0x143d8ea60a6a4011, ; 78: Microsoft.Extensions.DependencyInjection.Abstractions => 180
	i64 u0x1497051b917530bd, ; 79: lib_System.Net.WebSockets.dll.so => 81
	i64 u0x14e68447938213b7, ; 80: Xamarin.AndroidX.Collection.Ktx.dll => 210
	i64 u0x152a448bd1e745a7, ; 81: Microsoft.Win32.Primitives => 4
	i64 u0x1557de0138c445f4, ; 82: lib_Microsoft.Win32.Registry.dll.so => 5
	i64 u0x15bdc156ed462f2f, ; 83: lib_System.IO.FileSystem.dll.so => 51
	i64 u0x15e300c2c1668655, ; 84: System.Resources.Writer.dll => 101
	i64 u0x16bf2a22df043a09, ; 85: System.IO.Pipes.dll => 56
	i64 u0x16ea2b318ad2d830, ; 86: System.Security.Cryptography.Algorithms => 120
	i64 u0x16eeae54c7ebcc08, ; 87: System.Reflection.dll => 98
	i64 u0x17125c9a85b4929f, ; 88: lib_netstandard.dll.so => 168
	i64 u0x1716866f7416792e, ; 89: lib_System.Security.AccessControl.dll.so => 118
	i64 u0x174f71c46216e44a, ; 90: Xamarin.KotlinX.Coroutines.Core => 279
	i64 u0x1752c12f1e1fc00c, ; 91: System.Core => 21
	i64 u0x17b56e25558a5d36, ; 92: lib-hu-Microsoft.Maui.Controls.resources.dll.so => 295
	i64 u0x17f9358913beb16a, ; 93: System.Text.Encodings.Web => 137
	i64 u0x1809fb23f29ba44a, ; 94: lib_System.Reflection.TypeExtensions.dll.so => 97
	i64 u0x18402a709e357f3b, ; 95: lib_Xamarin.KotlinX.Serialization.Core.Jvm.dll.so => 282
	i64 u0x18a9befae51bb361, ; 96: System.Net.WebClient => 77
	i64 u0x18f0ce884e87d89a, ; 97: nb/Microsoft.Maui.Controls.resources.dll => 301
	i64 u0x193d7a04b7eda8bc, ; 98: lib_Xamarin.AndroidX.Print.dll.so => 250
	i64 u0x19777fba3c41b398, ; 99: Xamarin.AndroidX.Startup.StartupRuntime.dll => 258
	i64 u0x19a4c090f14ebb66, ; 100: System.Security.Claims => 119
	i64 u0x1a91866a319e9259, ; 101: lib_System.Collections.Concurrent.dll.so => 8
	i64 u0x1aac34d1917ba5d3, ; 102: lib_System.dll.so => 165
	i64 u0x1aad60783ffa3e5b, ; 103: lib-th-Microsoft.Maui.Controls.resources.dll.so => 310
	i64 u0x1aea8f1c3b282172, ; 104: lib_System.Net.Ping.dll.so => 70
	i64 u0x1b4b7a1d0d265fa2, ; 105: Xamarin.Android.Glide.DiskLruCache => 195
	i64 u0x1bbdb16cfa73e785, ; 106: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.Android => 239
	i64 u0x1bc766e07b2b4241, ; 107: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 253
	i64 u0x1c753b5ff15bce1b, ; 108: Mono.Android.Runtime.dll => 171
	i64 u0x1cd47467799d8250, ; 109: System.Threading.Tasks.dll => 145
	i64 u0x1d23eafdc6dc346c, ; 110: System.Globalization.Calendars.dll => 40
	i64 u0x1da4110562816681, ; 111: Xamarin.AndroidX.Security.SecurityCrypto.dll => 256
	i64 u0x1db6820994506bf5, ; 112: System.IO.FileSystem.AccessControl.dll => 47
	i64 u0x1dbb0c2c6a999acb, ; 113: System.Diagnostics.StackTrace => 30
	i64 u0x1e3d87657e9659bc, ; 114: Xamarin.AndroidX.Navigation.UI => 249
	i64 u0x1e71143913d56c10, ; 115: lib-ko-Microsoft.Maui.Controls.resources.dll.so => 299
	i64 u0x1e7c31185e2fb266, ; 116: lib_System.Threading.Tasks.Parallel.dll.so => 144
	i64 u0x1ed8fcce5e9b50a0, ; 117: Microsoft.Extensions.Options.dll => 184
	i64 u0x1f055d15d807e1b2, ; 118: System.Xml.XmlSerializer => 163
	i64 u0x1f1ed22c1085f044, ; 119: lib_System.Diagnostics.FileVersionInfo.dll.so => 28
	i64 u0x1f61df9c5b94d2c1, ; 120: lib_System.Numerics.dll.so => 84
	i64 u0x1f750bb5421397de, ; 121: lib_Xamarin.AndroidX.Tracing.Tracing.dll.so => 260
	i64 u0x20237ea48006d7a8, ; 122: lib_System.Net.WebClient.dll.so => 77
	i64 u0x209375905fcc1bad, ; 123: lib_System.IO.Compression.Brotli.dll.so => 43
	i64 u0x20fab3cf2dfbc8df, ; 124: lib_System.Diagnostics.Process.dll.so => 29
	i64 u0x2110167c128cba15, ; 125: System.Globalization => 42
	i64 u0x21419508838f7547, ; 126: System.Runtime.CompilerServices.VisualC => 103
	i64 u0x2174319c0d835bc9, ; 127: System.Runtime => 117
	i64 u0x2198e5bc8b7153fa, ; 128: Xamarin.AndroidX.Annotation.Experimental.dll => 200
	i64 u0x219ea1b751a4dee4, ; 129: lib_System.IO.Compression.ZipFile.dll.so => 45
	i64 u0x21cc7e445dcd5469, ; 130: System.Reflection.Emit.ILGeneration => 91
	i64 u0x220fd4f2e7c48170, ; 131: th/Microsoft.Maui.Controls.resources => 310
	i64 u0x224538d85ed15a82, ; 132: System.IO.Pipes => 56
	i64 u0x22908438c6bed1af, ; 133: lib_System.Threading.Timer.dll.so => 148
	i64 u0x237be844f1f812c7, ; 134: System.Threading.Thread.dll => 146
	i64 u0x23852b3bdc9f7096, ; 135: System.Resources.ResourceManager => 100
	i64 u0x23986dd7e5d4fc01, ; 136: System.IO.FileSystem.Primitives.dll => 49
	i64 u0x2399888a109f4a53, ; 137: WebApiClient.dll => 318
	i64 u0x2407aef2bbe8fadf, ; 138: System.Console => 20
	i64 u0x240abe014b27e7d3, ; 139: Xamarin.AndroidX.Core.dll => 215
	i64 u0x247619fe4413f8bf, ; 140: System.Runtime.Serialization.Primitives.dll => 114
	i64 u0x24de8d301281575e, ; 141: Xamarin.Android.Glide => 193
	i64 u0x252073cc3caa62c2, ; 142: fr/Microsoft.Maui.Controls.resources.dll => 291
	i64 u0x256b8d41255f01b1, ; 143: Xamarin.Google.Crypto.Tink.Android => 271
	i64 u0x2662c629b96b0b30, ; 144: lib_Xamarin.Kotlin.StdLib.dll.so => 275
	i64 u0x268c1439f13bcc29, ; 145: lib_Microsoft.Extensions.Primitives.dll.so => 185
	i64 u0x26a670e154a9c54b, ; 146: System.Reflection.Extensions.dll => 94
	i64 u0x26d077d9678fe34f, ; 147: System.IO.dll => 58
	i64 u0x273f3515de5faf0d, ; 148: id/Microsoft.Maui.Controls.resources.dll => 296
	i64 u0x2742545f9094896d, ; 149: hr/Microsoft.Maui.Controls.resources => 294
	i64 u0x2759af78ab94d39b, ; 150: System.Net.WebSockets => 81
	i64 u0x27b2b16f3e9de038, ; 151: Xamarin.Google.Crypto.Tink.Android.dll => 271
	i64 u0x27b410442fad6cf1, ; 152: Java.Interop.dll => 169
	i64 u0x27b97e0d52c3034a, ; 153: System.Diagnostics.Debug => 26
	i64 u0x2801845a2c71fbfb, ; 154: System.Net.Primitives.dll => 71
	i64 u0x286835e259162700, ; 155: lib_Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll.so => 251
	i64 u0x2949f3617a02c6b2, ; 156: Xamarin.AndroidX.ExifInterface => 225
	i64 u0x2a128783efe70ba0, ; 157: uk/Microsoft.Maui.Controls.resources.dll => 312
	i64 u0x2a3b095612184159, ; 158: lib_System.Net.NetworkInformation.dll.so => 69
	i64 u0x2a46533036000817, ; 159: WebApiClient => 318
	i64 u0x2a6507a5ffabdf28, ; 160: System.Diagnostics.TraceSource.dll => 33
	i64 u0x2ad156c8e1354139, ; 161: fi/Microsoft.Maui.Controls.resources => 290
	i64 u0x2ad5d6b13b7a3e04, ; 162: System.ComponentModel.DataAnnotations.dll => 14
	i64 u0x2af298f63581d886, ; 163: System.Text.RegularExpressions.dll => 139
	i64 u0x2afc1c4f898552ee, ; 164: lib_System.Formats.Asn1.dll.so => 38
	i64 u0x2b148910ed40fbf9, ; 165: zh-Hant/Microsoft.Maui.Controls.resources.dll => 316
	i64 u0x2b6989d78cba9a15, ; 166: Xamarin.AndroidX.Concurrent.Futures.dll => 211
	i64 u0x2c8bd14bb93a7d82, ; 167: lib-pl-Microsoft.Maui.Controls.resources.dll.so => 303
	i64 u0x2cbd9262ca785540, ; 168: lib_System.Text.Encoding.CodePages.dll.so => 134
	i64 u0x2cc9e1fed6257257, ; 169: lib_System.Reflection.Emit.Lightweight.dll.so => 92
	i64 u0x2cd723e9fe623c7c, ; 170: lib_System.Private.Xml.Linq.dll.so => 88
	i64 u0x2d169d318a968379, ; 171: System.Threading.dll => 149
	i64 u0x2d47774b7d993f59, ; 172: sv/Microsoft.Maui.Controls.resources.dll => 309
	i64 u0x2d5ffcae1ad0aaca, ; 173: System.Data.dll => 24
	i64 u0x2db915caf23548d2, ; 174: System.Text.Json.dll => 138
	i64 u0x2dcaa0bb15a4117a, ; 175: System.IO.UnmanagedMemoryStream.dll => 57
	i64 u0x2e5a40c319acb800, ; 176: System.IO.FileSystem => 51
	i64 u0x2e6f1f226821322a, ; 177: el/Microsoft.Maui.Controls.resources.dll => 288
	i64 u0x2f02f94df3200fe5, ; 178: System.Diagnostics.Process => 29
	i64 u0x2f2e98e1c89b1aff, ; 179: System.Xml.ReaderWriter => 157
	i64 u0x2f5911d9ba814e4e, ; 180: System.Diagnostics.Tracing => 34
	i64 u0x2f84070a459bc31f, ; 181: lib_System.Xml.dll.so => 164
	i64 u0x309ee9eeec09a71e, ; 182: lib_Xamarin.AndroidX.Fragment.dll.so => 226
	i64 u0x30c6dda129408828, ; 183: System.IO.IsolatedStorage => 52
	i64 u0x31195fef5d8fb552, ; 184: _Microsoft.Android.Resource.Designer.dll => 319
	i64 u0x312c8ed623cbfc8d, ; 185: Xamarin.AndroidX.Window.dll => 267
	i64 u0x31496b779ed0663d, ; 186: lib_System.Reflection.DispatchProxy.dll.so => 90
	i64 u0x32243413e774362a, ; 187: Xamarin.AndroidX.CardView.dll => 207
	i64 u0x3235427f8d12dae1, ; 188: lib_System.Drawing.Primitives.dll.so => 35
	i64 u0x329753a17a517811, ; 189: fr/Microsoft.Maui.Controls.resources => 291
	i64 u0x32aa989ff07a84ff, ; 190: lib_System.Xml.ReaderWriter.dll.so => 157
	i64 u0x33829542f112d59b, ; 191: System.Collections.Immutable => 9
	i64 u0x33a31443733849fe, ; 192: lib-es-Microsoft.Maui.Controls.resources.dll.so => 289
	i64 u0x341abc357fbb4ebf, ; 193: lib_System.Net.Sockets.dll.so => 76
	i64 u0x3496c1e2dcaf5ecc, ; 194: lib_System.IO.Pipes.AccessControl.dll.so => 55
	i64 u0x34dfd74fe2afcf37, ; 195: Microsoft.Maui => 188
	i64 u0x34e292762d9615df, ; 196: cs/Microsoft.Maui.Controls.resources.dll => 285
	i64 u0x3508234247f48404, ; 197: Microsoft.Maui.Controls => 186
	i64 u0x353590da528c9d22, ; 198: System.ComponentModel.Annotations => 13
	i64 u0x3549870798b4cd30, ; 199: lib_Xamarin.AndroidX.ViewPager2.dll.so => 266
	i64 u0x355282fc1c909694, ; 200: Microsoft.Extensions.Configuration => 177
	i64 u0x3552fc5d578f0fbf, ; 201: Xamarin.AndroidX.Arch.Core.Common => 204
	i64 u0x355c649948d55d97, ; 202: lib_System.Runtime.Intrinsics.dll.so => 109
	i64 u0x35ea9d1c6834bc8c, ; 203: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 242
	i64 u0x3628ab68db23a01a, ; 204: lib_System.Diagnostics.Tools.dll.so => 32
	i64 u0x3673b042508f5b6b, ; 205: lib_System.Runtime.Extensions.dll.so => 104
	i64 u0x36740f1a8ecdc6c4, ; 206: System.Numerics => 84
	i64 u0x36b2b50fdf589ae2, ; 207: System.Reflection.Emit.Lightweight => 92
	i64 u0x36cada77dc79928b, ; 208: System.IO.MemoryMappedFiles => 53
	i64 u0x374ef46b06791af6, ; 209: System.Reflection.Primitives.dll => 96
	i64 u0x376bf93e521a5417, ; 210: lib_Xamarin.Jetbrains.Annotations.dll.so => 274
	i64 u0x37bc29f3183003b6, ; 211: lib_System.IO.dll.so => 58
	i64 u0x380134e03b1e160a, ; 212: System.Collections.Immutable.dll => 9
	i64 u0x38049b5c59b39324, ; 213: System.Runtime.CompilerServices.Unsafe => 102
	i64 u0x385c17636bb6fe6e, ; 214: Xamarin.AndroidX.CustomView.dll => 218
	i64 u0x38869c811d74050e, ; 215: System.Net.NameResolution.dll => 68
	i64 u0x393c226616977fdb, ; 216: lib_Xamarin.AndroidX.ViewPager.dll.so => 265
	i64 u0x395e37c3334cf82a, ; 217: lib-ca-Microsoft.Maui.Controls.resources.dll.so => 284
	i64 u0x39aa39fda111d9d3, ; 218: Newtonsoft.Json => 191
	i64 u0x3ab5859054645f72, ; 219: System.Security.Cryptography.Primitives.dll => 125
	i64 u0x3ad75090c3fac0e9, ; 220: lib_Xamarin.AndroidX.ResourceInspection.Annotation.dll.so => 253
	i64 u0x3ae44ac43a1fbdbb, ; 221: System.Runtime.Serialization => 116
	i64 u0x3b6894af158dd739, ; 222: System.Net.Http.Formatting => 176
	i64 u0x3b860f9932505633, ; 223: lib_System.Text.Encoding.Extensions.dll.so => 135
	i64 u0x3c3aafb6b3a00bf6, ; 224: lib_System.Security.Cryptography.X509Certificates.dll.so => 126
	i64 u0x3c4049146b59aa90, ; 225: System.Runtime.InteropServices.JavaScript => 106
	i64 u0x3c7c495f58ac5ee9, ; 226: Xamarin.Kotlin.StdLib => 275
	i64 u0x3c7e5ed3d5db71bb, ; 227: System.Security => 131
	i64 u0x3cd9d281d402eb9b, ; 228: Xamarin.AndroidX.Browser.dll => 206
	i64 u0x3d1c50cc001a991e, ; 229: Xamarin.Google.Guava.ListenableFuture.dll => 273
	i64 u0x3d2b1913edfc08d7, ; 230: lib_System.Threading.ThreadPool.dll.so => 147
	i64 u0x3d46f0b995082740, ; 231: System.Xml.Linq => 156
	i64 u0x3d8a8f400514a790, ; 232: Xamarin.AndroidX.Fragment.Ktx.dll => 227
	i64 u0x3d9c2a242b040a50, ; 233: lib_Xamarin.AndroidX.Core.dll.so => 215
	i64 u0x3dbb6b9f5ab90fa7, ; 234: lib_Xamarin.AndroidX.DynamicAnimation.dll.so => 222
	i64 u0x3e5441657549b213, ; 235: Xamarin.AndroidX.ResourceInspection.Annotation => 253
	i64 u0x3e57d4d195c53c2e, ; 236: System.Reflection.TypeExtensions => 97
	i64 u0x3e616ab4ed1f3f15, ; 237: lib_System.Data.dll.so => 24
	i64 u0x3ec86cae1f1dfdec, ; 238: Docker.DotNet => 174
	i64 u0x3f1d226e6e06db7e, ; 239: Xamarin.AndroidX.SlidingPaneLayout.dll => 257
	i64 u0x3f510adf788828dd, ; 240: System.Threading.Tasks.Extensions => 143
	i64 u0x407740ff2e914d86, ; 241: Xamarin.AndroidX.Print.dll => 250
	i64 u0x407a10bb4bf95829, ; 242: lib_Xamarin.AndroidX.Navigation.Common.dll.so => 246
	i64 u0x40c98b6bd77346d4, ; 243: Microsoft.VisualBasic.dll => 3
	i64 u0x41833cf766d27d96, ; 244: mscorlib => 167
	i64 u0x41cab042be111c34, ; 245: lib_Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so => 203
	i64 u0x423a9ecc4d905a88, ; 246: lib_System.Resources.ResourceManager.dll.so => 100
	i64 u0x423bf51ae7def810, ; 247: System.Xml.XPath => 161
	i64 u0x42462ff15ddba223, ; 248: System.Resources.Reader.dll => 99
	i64 u0x4247073bab38ddaa, ; 249: MallPhoneApp.dll => 0
	i64 u0x42a31b86e6ccc3f0, ; 250: System.Diagnostics.Contracts => 25
	i64 u0x430e95b891249788, ; 251: lib_System.Reflection.Emit.dll.so => 93
	i64 u0x43375950ec7c1b6a, ; 252: netstandard.dll => 168
	i64 u0x434c4e1d9284cdae, ; 253: Mono.Android.dll => 172
	i64 u0x43505013578652a0, ; 254: lib_Xamarin.AndroidX.Activity.Ktx.dll.so => 198
	i64 u0x437d06c381ed575a, ; 255: lib_Microsoft.VisualBasic.dll.so => 3
	i64 u0x43950f84de7cc79a, ; 256: pl/Microsoft.Maui.Controls.resources.dll => 303
	i64 u0x43e8ca5bc927ff37, ; 257: lib_Xamarin.AndroidX.Emoji2.ViewsHelper.dll.so => 224
	i64 u0x448bd33429269b19, ; 258: Microsoft.CSharp => 1
	i64 u0x4499fa3c8e494654, ; 259: lib_System.Runtime.Serialization.Primitives.dll.so => 114
	i64 u0x4515080865a951a5, ; 260: Xamarin.Kotlin.StdLib.dll => 275
	i64 u0x4545802489b736b9, ; 261: Xamarin.AndroidX.Fragment.Ktx => 227
	i64 u0x454b4d1e66bb783c, ; 262: Xamarin.AndroidX.Lifecycle.Process => 235
	i64 u0x45c40276a42e283e, ; 263: System.Diagnostics.TraceSource => 33
	i64 u0x45d443f2a29adc37, ; 264: System.AppContext.dll => 6
	i64 u0x46a4213bc97fe5ae, ; 265: lib-ru-Microsoft.Maui.Controls.resources.dll.so => 307
	i64 u0x47358bd471172e1d, ; 266: lib_System.Xml.Linq.dll.so => 156
	i64 u0x47daf4e1afbada10, ; 267: pt/Microsoft.Maui.Controls.resources => 305
	i64 u0x480c0a47dd42dd81, ; 268: lib_System.IO.MemoryMappedFiles.dll.so => 53
	i64 u0x488d293220a4fe37, ; 269: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 229
	i64 u0x49e952f19a4e2022, ; 270: System.ObjectModel => 85
	i64 u0x49f9e6948a8131e4, ; 271: lib_Xamarin.AndroidX.VersionedParcelable.dll.so => 264
	i64 u0x4a5667b2462a664b, ; 272: lib_Xamarin.AndroidX.Navigation.UI.dll.so => 249
	i64 u0x4a7a18981dbd56bc, ; 273: System.IO.Compression.FileSystem.dll => 44
	i64 u0x4aa5c60350917c06, ; 274: lib_Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll.so => 234
	i64 u0x4b07a0ed0ab33ff4, ; 275: System.Runtime.Extensions.dll => 104
	i64 u0x4b576d47ac054f3c, ; 276: System.IO.FileSystem.AccessControl => 47
	i64 u0x4b7b6532ded934b7, ; 277: System.Text.Json => 138
	i64 u0x4c7755cf07ad2d5f, ; 278: System.Net.Http.Json.dll => 64
	i64 u0x4cc5f15266470798, ; 279: lib_Xamarin.AndroidX.Loader.dll.so => 244
	i64 u0x4cf6f67dc77aacd2, ; 280: System.Net.NetworkInformation.dll => 69
	i64 u0x4d3183dd245425d4, ; 281: System.Net.WebSockets.Client.dll => 80
	i64 u0x4d479f968a05e504, ; 282: System.Linq.Expressions.dll => 59
	i64 u0x4d55a010ffc4faff, ; 283: System.Private.Xml => 89
	i64 u0x4d5cbe77561c5b2e, ; 284: System.Web.dll => 154
	i64 u0x4d77512dbd86ee4c, ; 285: lib_Xamarin.AndroidX.Arch.Core.Common.dll.so => 204
	i64 u0x4d7793536e79c309, ; 286: System.ServiceProcess => 133
	i64 u0x4d95fccc1f67c7ca, ; 287: System.Runtime.Loader.dll => 110
	i64 u0x4dcf44c3c9b076a2, ; 288: it/Microsoft.Maui.Controls.resources.dll => 297
	i64 u0x4dd9247f1d2c3235, ; 289: Xamarin.AndroidX.Loader.dll => 244
	i64 u0x4e2aeee78e2c4a87, ; 290: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 251
	i64 u0x4e32f00cb0937401, ; 291: Mono.Android.Runtime => 171
	i64 u0x4e5eea4668ac2b18, ; 292: System.Text.Encoding.CodePages => 134
	i64 u0x4ebd0c4b82c5eefc, ; 293: lib_System.Threading.Channels.dll.so => 140
	i64 u0x4ee8eaa9c9c1151a, ; 294: System.Globalization.Calendars => 40
	i64 u0x4f1457389bc1b2a1, ; 295: lib_Docker.DotNet.dll.so => 174
	i64 u0x4f21ee6ef9eb527e, ; 296: ca/Microsoft.Maui.Controls.resources => 284
	i64 u0x5037f0be3c28c7a3, ; 297: lib_Microsoft.Maui.Controls.dll.so => 186
	i64 u0x50c3a29b21050d45, ; 298: System.Linq.Parallel.dll => 60
	i64 u0x5131bbe80989093f, ; 299: Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll => 241
	i64 u0x516324a5050a7e3c, ; 300: System.Net.WebProxy => 79
	i64 u0x516d6f0b21a303de, ; 301: lib_System.Diagnostics.Contracts.dll.so => 25
	i64 u0x51bb8a2afe774e32, ; 302: System.Drawing => 36
	i64 u0x5247c5c32a4140f0, ; 303: System.Resources.Reader => 99
	i64 u0x526bb15e3c386364, ; 304: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 238
	i64 u0x526ce79eb8e90527, ; 305: lib_System.Net.Primitives.dll.so => 71
	i64 u0x52829f00b4467c38, ; 306: lib_System.Data.Common.dll.so => 22
	i64 u0x529ffe06f39ab8db, ; 307: Xamarin.AndroidX.Core => 215
	i64 u0x52ff996554dbf352, ; 308: Microsoft.Maui.Graphics => 190
	i64 u0x535f7e40e8fef8af, ; 309: lib-sk-Microsoft.Maui.Controls.resources.dll.so => 308
	i64 u0x53978aac584c666e, ; 310: lib_System.Security.Cryptography.Cng.dll.so => 121
	i64 u0x53a96d5c86c9e194, ; 311: System.Net.NetworkInformation => 69
	i64 u0x53be1038a61e8d44, ; 312: System.Runtime.InteropServices.RuntimeInformation.dll => 107
	i64 u0x53c3014b9437e684, ; 313: lib-zh-HK-Microsoft.Maui.Controls.resources.dll.so => 314
	i64 u0x53e450ebd586f842, ; 314: lib_Xamarin.AndroidX.LocalBroadcastManager.dll.so => 245
	i64 u0x5435e6f049e9bc37, ; 315: System.Security.Claims.dll => 119
	i64 u0x54795225dd1587af, ; 316: lib_System.Runtime.dll.so => 117
	i64 u0x547a34f14e5f6210, ; 317: Xamarin.AndroidX.Lifecycle.Common.dll => 230
	i64 u0x556e8b63b660ab8b, ; 318: Xamarin.AndroidX.Lifecycle.Common.Jvm.dll => 231
	i64 u0x5588627c9a108ec9, ; 319: System.Collections.Specialized => 11
	i64 u0x55a898e4f42e3fae, ; 320: Microsoft.VisualBasic.Core.dll => 2
	i64 u0x55fa0c610fe93bb1, ; 321: lib_System.Security.Cryptography.OpenSsl.dll.so => 124
	i64 u0x56442b99bc64bb47, ; 322: System.Runtime.Serialization.Xml.dll => 115
	i64 u0x56a8b26e1aeae27b, ; 323: System.Threading.Tasks.Dataflow => 142
	i64 u0x56f932d61e93c07f, ; 324: System.Globalization.Extensions => 41
	i64 u0x571c5cfbec5ae8e2, ; 325: System.Private.Uri => 87
	i64 u0x575656993e465a4f, ; 326: lib_MallPhoneApp.dll.so => 0
	i64 u0x576499c9f52fea31, ; 327: Xamarin.AndroidX.Annotation => 199
	i64 u0x579a06fed6eec900, ; 328: System.Private.CoreLib.dll => 173
	i64 u0x57c542c14049b66d, ; 329: System.Diagnostics.DiagnosticSource => 27
	i64 u0x581a8bd5cfda563e, ; 330: System.Threading.Timer => 148
	i64 u0x58601b2dda4a27b9, ; 331: lib-ja-Microsoft.Maui.Controls.resources.dll.so => 298
	i64 u0x58688d9af496b168, ; 332: Microsoft.Extensions.DependencyInjection.dll => 179
	i64 u0x588c167a79db6bfb, ; 333: lib_Xamarin.Google.ErrorProne.Annotations.dll.so => 272
	i64 u0x5906028ae5151104, ; 334: Xamarin.AndroidX.Activity.Ktx => 198
	i64 u0x595a356d23e8da9a, ; 335: lib_Microsoft.CSharp.dll.so => 1
	i64 u0x59f9e60b9475085f, ; 336: lib_Xamarin.AndroidX.Annotation.Experimental.dll.so => 200
	i64 u0x5a745f5101a75527, ; 337: lib_System.IO.Compression.FileSystem.dll.so => 44
	i64 u0x5a89a886ae30258d, ; 338: lib_Xamarin.AndroidX.CoordinatorLayout.dll.so => 214
	i64 u0x5a8f6699f4a1caa9, ; 339: lib_System.Threading.dll.so => 149
	i64 u0x5ae8e4f3eae4d547, ; 340: Xamarin.AndroidX.Legacy.Support.Core.Utils => 229
	i64 u0x5ae9cd33b15841bf, ; 341: System.ComponentModel => 18
	i64 u0x5b54391bdc6fcfe6, ; 342: System.Private.DataContractSerialization => 86
	i64 u0x5b5f0e240a06a2a2, ; 343: da/Microsoft.Maui.Controls.resources.dll => 286
	i64 u0x5b8109e8e14c5e3e, ; 344: System.Globalization.Extensions.dll => 41
	i64 u0x5bddd04d72a9e350, ; 345: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 234
	i64 u0x5bdf16b09da116ab, ; 346: Xamarin.AndroidX.Collection => 208
	i64 u0x5c019d5266093159, ; 347: lib_Xamarin.AndroidX.Lifecycle.Runtime.Ktx.Android.dll.so => 239
	i64 u0x5c30a4a35f9cc8c4, ; 348: lib_System.Reflection.Extensions.dll.so => 94
	i64 u0x5c393624b8176517, ; 349: lib_Microsoft.Extensions.Logging.dll.so => 181
	i64 u0x5c53c29f5073b0c9, ; 350: System.Diagnostics.FileVersionInfo => 28
	i64 u0x5c87463c575c7616, ; 351: lib_System.Globalization.Extensions.dll.so => 41
	i64 u0x5d0a4a29b02d9d3c, ; 352: System.Net.WebHeaderCollection.dll => 78
	i64 u0x5d40c9b15181641f, ; 353: lib_Xamarin.AndroidX.Emoji2.dll.so => 223
	i64 u0x5d6ca10d35e9485b, ; 354: lib_Xamarin.AndroidX.Concurrent.Futures.dll.so => 211
	i64 u0x5d7ec76c1c703055, ; 355: System.Threading.Tasks.Parallel => 144
	i64 u0x5db0cbbd1028510e, ; 356: lib_System.Runtime.InteropServices.dll.so => 108
	i64 u0x5db30905d3e5013b, ; 357: Xamarin.AndroidX.Collection.Jvm.dll => 209
	i64 u0x5e467bc8f09ad026, ; 358: System.Collections.Specialized.dll => 11
	i64 u0x5e5173b3208d97e7, ; 359: System.Runtime.Handles.dll => 105
	i64 u0x5ea92fdb19ec8c4c, ; 360: System.Text.Encodings.Web.dll => 137
	i64 u0x5eb8046dd40e9ac3, ; 361: System.ComponentModel.Primitives => 16
	i64 u0x5ec272d219c9aba4, ; 362: System.Security.Cryptography.Csp.dll => 122
	i64 u0x5eee1376d94c7f5e, ; 363: System.Net.HttpListener.dll => 66
	i64 u0x5f36ccf5c6a57e24, ; 364: System.Xml.ReaderWriter.dll => 157
	i64 u0x5f4294b9b63cb842, ; 365: System.Data.Common => 22
	i64 u0x5f9a2d823f664957, ; 366: lib-el-Microsoft.Maui.Controls.resources.dll.so => 288
	i64 u0x5fa6da9c3cd8142a, ; 367: lib_Xamarin.KotlinX.Serialization.Core.dll.so => 281
	i64 u0x5fac98e0b37a5b9d, ; 368: System.Runtime.CompilerServices.Unsafe.dll => 102
	i64 u0x609f4b7b63d802d4, ; 369: lib_Microsoft.Extensions.DependencyInjection.dll.so => 179
	i64 u0x60cd4e33d7e60134, ; 370: Xamarin.KotlinX.Coroutines.Core.Jvm => 280
	i64 u0x60f62d786afcf130, ; 371: System.Memory => 63
	i64 u0x61bb78c89f867353, ; 372: System.IO => 58
	i64 u0x61be8d1299194243, ; 373: Microsoft.Maui.Controls.Xaml => 187
	i64 u0x61d2cba29557038f, ; 374: de/Microsoft.Maui.Controls.resources => 287
	i64 u0x61d88f399afb2f45, ; 375: lib_System.Runtime.Loader.dll.so => 110
	i64 u0x622eef6f9e59068d, ; 376: System.Private.CoreLib => 173
	i64 u0x63d5e3aa4ef9b931, ; 377: Xamarin.KotlinX.Coroutines.Android.dll => 278
	i64 u0x63f1f6883c1e23c2, ; 378: lib_System.Collections.Immutable.dll.so => 9
	i64 u0x6400f68068c1e9f1, ; 379: Xamarin.Google.Android.Material.dll => 269
	i64 u0x640e3b14dbd325c2, ; 380: System.Security.Cryptography.Algorithms.dll => 120
	i64 u0x64587004560099b9, ; 381: System.Reflection => 98
	i64 u0x64b1529a438a3c45, ; 382: lib_System.Runtime.Handles.dll.so => 105
	i64 u0x6565fba2cd8f235b, ; 383: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 242
	i64 u0x65ecac39144dd3cc, ; 384: Microsoft.Maui.Controls.dll => 186
	i64 u0x65ece51227bfa724, ; 385: lib_System.Runtime.Numerics.dll.so => 111
	i64 u0x661722438787b57f, ; 386: Xamarin.AndroidX.Annotation.Jvm.dll => 201
	i64 u0x6679b2337ee6b22a, ; 387: lib_System.IO.FileSystem.Primitives.dll.so => 49
	i64 u0x6692e924eade1b29, ; 388: lib_System.Console.dll.so => 20
	i64 u0x66a4e5c6a3fb0bae, ; 389: lib_Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll.so => 241
	i64 u0x66d13304ce1a3efa, ; 390: Xamarin.AndroidX.CursorAdapter => 217
	i64 u0x674303f65d8fad6f, ; 391: lib_System.Net.Quic.dll.so => 72
	i64 u0x6756ca4cad62e9d6, ; 392: lib_Xamarin.AndroidX.ConstraintLayout.Core.dll.so => 213
	i64 u0x67c0802770244408, ; 393: System.Windows.dll => 155
	i64 u0x68100b69286e27cd, ; 394: lib_System.Formats.Tar.dll.so => 39
	i64 u0x68558ec653afa616, ; 395: lib-da-Microsoft.Maui.Controls.resources.dll.so => 286
	i64 u0x6872ec7a2e36b1ac, ; 396: System.Drawing.Primitives.dll => 35
	i64 u0x68bb2c417aa9b61c, ; 397: Xamarin.KotlinX.AtomicFU.dll => 276
	i64 u0x68fbbbe2eb455198, ; 398: System.Formats.Asn1 => 38
	i64 u0x69063fc0ba8e6bdd, ; 399: he/Microsoft.Maui.Controls.resources.dll => 292
	i64 u0x69a3e26c76f6eec4, ; 400: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 268
	i64 u0x6a4d7577b2317255, ; 401: System.Runtime.InteropServices.dll => 108
	i64 u0x6ace3b74b15ee4a4, ; 402: nb/Microsoft.Maui.Controls.resources => 301
	i64 u0x6afcedb171067e2b, ; 403: System.Core.dll => 21
	i64 u0x6bef98e124147c24, ; 404: Xamarin.Jetbrains.Annotations => 274
	i64 u0x6ce874bff138ce2b, ; 405: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 240
	i64 u0x6d12bfaa99c72b1f, ; 406: lib_Microsoft.Maui.Graphics.dll.so => 190
	i64 u0x6d70755158ca866e, ; 407: lib_System.ComponentModel.EventBasedAsync.dll.so => 15
	i64 u0x6d79993361e10ef2, ; 408: Microsoft.Extensions.Primitives => 185
	i64 u0x6d7eeca99577fc8b, ; 409: lib_System.Net.WebProxy.dll.so => 79
	i64 u0x6d8515b19946b6a2, ; 410: System.Net.WebProxy.dll => 79
	i64 u0x6d86d56b84c8eb71, ; 411: lib_Xamarin.AndroidX.CursorAdapter.dll.so => 217
	i64 u0x6d9bea6b3e895cf7, ; 412: Microsoft.Extensions.Primitives.dll => 185
	i64 u0x6dd9bf4083de3f6a, ; 413: Xamarin.AndroidX.DocumentFile.dll => 220
	i64 u0x6e25a02c3833319a, ; 414: lib_Xamarin.AndroidX.Navigation.Fragment.dll.so => 247
	i64 u0x6e79c6bd8627412a, ; 415: Xamarin.AndroidX.SavedState.SavedState.Ktx => 255
	i64 u0x6e838d9a2a6f6c9e, ; 416: lib_System.ValueTuple.dll.so => 152
	i64 u0x6e9965ce1095e60a, ; 417: lib_System.Core.dll.so => 21
	i64 u0x6fd2265da78b93a4, ; 418: lib_Microsoft.Maui.dll.so => 188
	i64 u0x6fdfc7de82c33008, ; 419: cs/Microsoft.Maui.Controls.resources => 285
	i64 u0x6ffc4967cc47ba57, ; 420: System.IO.FileSystem.Watcher.dll => 50
	i64 u0x701cd46a1c25a5fe, ; 421: System.IO.FileSystem.dll => 51
	i64 u0x70e99f48c05cb921, ; 422: tr/Microsoft.Maui.Controls.resources.dll => 311
	i64 u0x70fd3deda22442d2, ; 423: lib-nb-Microsoft.Maui.Controls.resources.dll.so => 301
	i64 u0x71485e7ffdb4b958, ; 424: System.Reflection.Extensions => 94
	i64 u0x7162a2fce67a945f, ; 425: lib_Xamarin.Android.Glide.Annotations.dll.so => 194
	i64 u0x71a495ea3761dde8, ; 426: lib-it-Microsoft.Maui.Controls.resources.dll.so => 297
	i64 u0x71ad672adbe48f35, ; 427: System.ComponentModel.Primitives.dll => 16
	i64 u0x725f5a9e82a45c81, ; 428: System.Security.Cryptography.Encoding => 123
	i64 u0x72b1fb4109e08d7b, ; 429: lib-hr-Microsoft.Maui.Controls.resources.dll.so => 294
	i64 u0x72e0300099accce1, ; 430: System.Xml.XPath.XDocument => 160
	i64 u0x730bfb248998f67a, ; 431: System.IO.Compression.ZipFile => 45
	i64 u0x732b2d67b9e5c47b, ; 432: Xamarin.Google.ErrorProne.Annotations.dll => 272
	i64 u0x734b76fdc0dc05bb, ; 433: lib_GoogleGson.dll.so => 175
	i64 u0x73a6be34e822f9d1, ; 434: lib_System.Runtime.Serialization.dll.so => 116
	i64 u0x73e4ce94e2eb6ffc, ; 435: lib_System.Memory.dll.so => 63
	i64 u0x743a1eccf080489a, ; 436: WindowsBase.dll => 166
	i64 u0x755a91767330b3d4, ; 437: lib_Microsoft.Extensions.Configuration.dll.so => 177
	i64 u0x75c326eb821b85c4, ; 438: lib_System.ComponentModel.DataAnnotations.dll.so => 14
	i64 u0x76012e7334db86e5, ; 439: lib_Xamarin.AndroidX.SavedState.dll.so => 254
	i64 u0x76ca07b878f44da0, ; 440: System.Runtime.Numerics.dll => 111
	i64 u0x7736c8a96e51a061, ; 441: lib_Xamarin.AndroidX.Annotation.Jvm.dll.so => 201
	i64 u0x778a805e625329ef, ; 442: System.Linq.Parallel => 60
	i64 u0x779290cc2b801eb7, ; 443: Xamarin.KotlinX.AtomicFU.Jvm => 277
	i64 u0x77f8a4acc2fdc449, ; 444: System.Security.Cryptography.Cng.dll => 121
	i64 u0x780bc73597a503a9, ; 445: lib-ms-Microsoft.Maui.Controls.resources.dll.so => 300
	i64 u0x782c5d8eb99ff201, ; 446: lib_Microsoft.VisualBasic.Core.dll.so => 2
	i64 u0x783606d1e53e7a1a, ; 447: th/Microsoft.Maui.Controls.resources.dll => 310
	i64 u0x78a45e51311409b6, ; 448: Xamarin.AndroidX.Fragment.dll => 226
	i64 u0x78ed4ab8f9d800a1, ; 449: Xamarin.AndroidX.Lifecycle.ViewModel => 240
	i64 u0x7a39601d6f0bb831, ; 450: lib_Xamarin.KotlinX.AtomicFU.dll.so => 276
	i64 u0x7a7e7eddf79c5d26, ; 451: lib_Xamarin.AndroidX.Lifecycle.ViewModel.dll.so => 240
	i64 u0x7a9a57d43b0845fa, ; 452: System.AppContext => 6
	i64 u0x7ad0f4f1e5d08183, ; 453: Xamarin.AndroidX.Collection.dll => 208
	i64 u0x7adb8da2ac89b647, ; 454: fi/Microsoft.Maui.Controls.resources.dll => 290
	i64 u0x7b13d9eaa944ade8, ; 455: Xamarin.AndroidX.DynamicAnimation.dll => 222
	i64 u0x7bef86a4335c4870, ; 456: System.ComponentModel.TypeConverter => 17
	i64 u0x7c0820144cd34d6a, ; 457: sk/Microsoft.Maui.Controls.resources.dll => 308
	i64 u0x7c2a0bd1e0f988fc, ; 458: lib-de-Microsoft.Maui.Controls.resources.dll.so => 287
	i64 u0x7c41d387501568ba, ; 459: System.Net.WebClient.dll => 77
	i64 u0x7c482cd79bd24b13, ; 460: lib_Xamarin.AndroidX.ConstraintLayout.dll.so => 212
	i64 u0x7cd2ec8eaf5241cd, ; 461: System.Security.dll => 131
	i64 u0x7cf9ae50dd350622, ; 462: Xamarin.Jetbrains.Annotations.dll => 274
	i64 u0x7d649b75d580bb42, ; 463: ms/Microsoft.Maui.Controls.resources.dll => 300
	i64 u0x7d8ee2bdc8e3aad1, ; 464: System.Numerics.Vectors => 83
	i64 u0x7df5df8db8eaa6ac, ; 465: Microsoft.Extensions.Logging.Debug => 183
	i64 u0x7dfc3d6d9d8d7b70, ; 466: System.Collections => 12
	i64 u0x7e2e564fa2f76c65, ; 467: lib_System.Diagnostics.Tracing.dll.so => 34
	i64 u0x7e302e110e1e1346, ; 468: lib_System.Security.Claims.dll.so => 119
	i64 u0x7e4465b3f78ad8d0, ; 469: Xamarin.KotlinX.Serialization.Core.dll => 281
	i64 u0x7e571cad5915e6c3, ; 470: lib_Xamarin.AndroidX.Lifecycle.Process.dll.so => 235
	i64 u0x7e6b1ca712437d7d, ; 471: Xamarin.AndroidX.Emoji2.ViewsHelper => 224
	i64 u0x7e946809d6008ef2, ; 472: lib_System.ObjectModel.dll.so => 85
	i64 u0x7ea0272c1b4a9635, ; 473: lib_Xamarin.Android.Glide.dll.so => 193
	i64 u0x7ecc13347c8fd849, ; 474: lib_System.ComponentModel.dll.so => 18
	i64 u0x7f00ddd9b9ca5a13, ; 475: Xamarin.AndroidX.ViewPager.dll => 265
	i64 u0x7f9351cd44b1273f, ; 476: Microsoft.Extensions.Configuration.Abstractions => 178
	i64 u0x7fbd557c99b3ce6f, ; 477: lib_Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so => 233
	i64 u0x8076a9a44a2ca331, ; 478: System.Net.Quic => 72
	i64 u0x80da183a87731838, ; 479: System.Reflection.Metadata => 95
	i64 u0x812c069d5cdecc17, ; 480: System.dll => 165
	i64 u0x81381be520a60adb, ; 481: Xamarin.AndroidX.Interpolator.dll => 228
	i64 u0x81657cec2b31e8aa, ; 482: System.Net => 82
	i64 u0x81ab745f6c0f5ce6, ; 483: zh-Hant/Microsoft.Maui.Controls.resources => 316
	i64 u0x8277f2be6b5ce05f, ; 484: Xamarin.AndroidX.AppCompat => 202
	i64 u0x828f06563b30bc50, ; 485: lib_Xamarin.AndroidX.CardView.dll.so => 207
	i64 u0x82920a8d9194a019, ; 486: Xamarin.KotlinX.AtomicFU.Jvm.dll => 277
	i64 u0x82b399cb01b531c4, ; 487: lib_System.Web.dll.so => 154
	i64 u0x82df8f5532a10c59, ; 488: lib_System.Drawing.dll.so => 36
	i64 u0x82f0b6e911d13535, ; 489: lib_System.Transactions.dll.so => 151
	i64 u0x82f6403342e12049, ; 490: uk/Microsoft.Maui.Controls.resources => 312
	i64 u0x83c14ba66c8e2b8c, ; 491: zh-Hans/Microsoft.Maui.Controls.resources => 315
	i64 u0x846ce984efea52c7, ; 492: System.Threading.Tasks.Parallel.dll => 144
	i64 u0x84ae73148a4557d2, ; 493: lib_System.IO.Pipes.dll.so => 56
	i64 u0x84b01102c12a9232, ; 494: System.Runtime.Serialization.Json.dll => 113
	i64 u0x850c5ba0b57ce8e7, ; 495: lib_Xamarin.AndroidX.Collection.dll.so => 208
	i64 u0x851d02edd334b044, ; 496: Xamarin.AndroidX.VectorDrawable => 262
	i64 u0x85c919db62150978, ; 497: Xamarin.AndroidX.Transition.dll => 261
	i64 u0x8662aaeb94fef37f, ; 498: lib_System.Dynamic.Runtime.dll.so => 37
	i64 u0x86a909228dc7657b, ; 499: lib-zh-Hant-Microsoft.Maui.Controls.resources.dll.so => 316
	i64 u0x86b3e00c36b84509, ; 500: Microsoft.Extensions.Configuration.dll => 177
	i64 u0x86b62cb077ec4fd7, ; 501: System.Runtime.Serialization.Xml => 115
	i64 u0x8706ffb12bf3f53d, ; 502: Xamarin.AndroidX.Annotation.Experimental => 200
	i64 u0x872a5b14c18d328c, ; 503: System.ComponentModel.DataAnnotations => 14
	i64 u0x872fb9615bc2dff0, ; 504: Xamarin.Android.Glide.Annotations.dll => 194
	i64 u0x87c69b87d9283884, ; 505: lib_System.Threading.Thread.dll.so => 146
	i64 u0x87f6569b25707834, ; 506: System.IO.Compression.Brotli.dll => 43
	i64 u0x8842b3a5d2d3fb36, ; 507: Microsoft.Maui.Essentials => 189
	i64 u0x88926583efe7ee86, ; 508: Xamarin.AndroidX.Activity.Ktx.dll => 198
	i64 u0x88ba6bc4f7762b03, ; 509: lib_System.Reflection.dll.so => 98
	i64 u0x88bda98e0cffb7a9, ; 510: lib_Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so => 280
	i64 u0x8930322c7bd8f768, ; 511: netstandard => 168
	i64 u0x897a606c9e39c75f, ; 512: lib_System.ComponentModel.Primitives.dll.so => 16
	i64 u0x89911a22005b92b7, ; 513: System.IO.FileSystem.DriveInfo.dll => 48
	i64 u0x89c5188089ec2cd5, ; 514: lib_System.Runtime.InteropServices.RuntimeInformation.dll.so => 107
	i64 u0x8a19e3dc71b34b2c, ; 515: System.Reflection.TypeExtensions.dll => 97
	i64 u0x8ad229ea26432ee2, ; 516: Xamarin.AndroidX.Loader => 244
	i64 u0x8b4ff5d0fdd5faa1, ; 517: lib_System.Diagnostics.DiagnosticSource.dll.so => 27
	i64 u0x8b541d476eb3774c, ; 518: System.Security.Principal.Windows => 128
	i64 u0x8b655d322ee548db, ; 519: lib_WebApiClient.dll.so => 318
	i64 u0x8b8d01333a96d0b5, ; 520: System.Diagnostics.Process.dll => 29
	i64 u0x8b9ceca7acae3451, ; 521: lib-he-Microsoft.Maui.Controls.resources.dll.so => 292
	i64 u0x8cb8f612b633affb, ; 522: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 255
	i64 u0x8cdfdb4ce85fb925, ; 523: lib_System.Security.Principal.Windows.dll.so => 128
	i64 u0x8cdfe7b8f4caa426, ; 524: System.IO.Compression.FileSystem => 44
	i64 u0x8d0f420977c2c1c7, ; 525: Xamarin.AndroidX.CursorAdapter.dll => 217
	i64 u0x8d52f7ea2796c531, ; 526: Xamarin.AndroidX.Emoji2.dll => 223
	i64 u0x8d7b8ab4b3310ead, ; 527: System.Threading => 149
	i64 u0x8da188285aadfe8e, ; 528: System.Collections.Concurrent => 8
	i64 u0x8e19d00123162f75, ; 529: MallPhoneApp => 0
	i64 u0x8ec6e06a61c1baeb, ; 530: lib_Newtonsoft.Json.dll.so => 191
	i64 u0x8ed807bfe9858dfc, ; 531: Xamarin.AndroidX.Navigation.Common => 246
	i64 u0x8ee08b8194a30f48, ; 532: lib-hi-Microsoft.Maui.Controls.resources.dll.so => 293
	i64 u0x8ef7601039857a44, ; 533: lib-ro-Microsoft.Maui.Controls.resources.dll.so => 306
	i64 u0x8f32c6f611f6ffab, ; 534: pt/Microsoft.Maui.Controls.resources.dll => 305
	i64 u0x8f44b45eb046bbd1, ; 535: System.ServiceModel.Web.dll => 132
	i64 u0x8f8829d21c8985a4, ; 536: lib-pt-BR-Microsoft.Maui.Controls.resources.dll.so => 304
	i64 u0x8fbf5b0114c6dcef, ; 537: System.Globalization.dll => 42
	i64 u0x8fcc8c2a81f3d9e7, ; 538: Xamarin.KotlinX.Serialization.Core => 281
	i64 u0x90263f8448b8f572, ; 539: lib_System.Diagnostics.TraceSource.dll.so => 33
	i64 u0x903101b46fb73a04, ; 540: _Microsoft.Android.Resource.Designer => 319
	i64 u0x90393bd4865292f3, ; 541: lib_System.IO.Compression.dll.so => 46
	i64 u0x905e2b8e7ae91ae6, ; 542: System.Threading.Tasks.Extensions.dll => 143
	i64 u0x90634f86c5ebe2b5, ; 543: Xamarin.AndroidX.Lifecycle.ViewModel.Android => 241
	i64 u0x907b636704ad79ef, ; 544: lib_Microsoft.Maui.Controls.Xaml.dll.so => 187
	i64 u0x90e9efbfd68593e0, ; 545: lib_Xamarin.AndroidX.Lifecycle.LiveData.dll.so => 232
	i64 u0x91418dc638b29e68, ; 546: lib_Xamarin.AndroidX.CustomView.dll.so => 218
	i64 u0x9157bd523cd7ed36, ; 547: lib_System.Text.Json.dll.so => 138
	i64 u0x91a74f07b30d37e2, ; 548: System.Linq.dll => 62
	i64 u0x91cb86ea3b17111d, ; 549: System.ServiceModel.Web => 132
	i64 u0x91fa41a87223399f, ; 550: ca/Microsoft.Maui.Controls.resources.dll => 284
	i64 u0x92054e486c0c7ea7, ; 551: System.IO.FileSystem.DriveInfo => 48
	i64 u0x928614058c40c4cd, ; 552: lib_System.Xml.XPath.XDocument.dll.so => 160
	i64 u0x92b138fffca2b01e, ; 553: lib_Xamarin.AndroidX.Arch.Core.Runtime.dll.so => 205
	i64 u0x92dfc2bfc6c6a888, ; 554: Xamarin.AndroidX.Lifecycle.LiveData => 232
	i64 u0x933da2c779423d68, ; 555: Xamarin.Android.Glide.Annotations => 194
	i64 u0x9388aad9b7ae40ce, ; 556: lib_Xamarin.AndroidX.Lifecycle.Common.dll.so => 230
	i64 u0x93cfa73ab28d6e35, ; 557: ms/Microsoft.Maui.Controls.resources => 300
	i64 u0x941c00d21e5c0679, ; 558: lib_Xamarin.AndroidX.Transition.dll.so => 261
	i64 u0x944077d8ca3c6580, ; 559: System.IO.Compression.dll => 46
	i64 u0x948cffedc8ed7960, ; 560: System.Xml => 164
	i64 u0x94c8990839c4bdb1, ; 561: lib_Xamarin.AndroidX.Interpolator.dll.so => 228
	i64 u0x967fc325e09bfa8c, ; 562: es/Microsoft.Maui.Controls.resources => 289
	i64 u0x9686161486d34b81, ; 563: lib_Xamarin.AndroidX.ExifInterface.dll.so => 225
	i64 u0x9732d8dbddea3d9a, ; 564: id/Microsoft.Maui.Controls.resources => 296
	i64 u0x978be80e5210d31b, ; 565: Microsoft.Maui.Graphics.dll => 190
	i64 u0x97b8c771ea3e4220, ; 566: System.ComponentModel.dll => 18
	i64 u0x97e144c9d3c6976e, ; 567: System.Collections.Concurrent.dll => 8
	i64 u0x984184e3c70d4419, ; 568: GoogleGson => 175
	i64 u0x9843944103683dd3, ; 569: Xamarin.AndroidX.Core.Core.Ktx => 216
	i64 u0x98d720cc4597562c, ; 570: System.Security.Cryptography.OpenSsl => 124
	i64 u0x991d510397f92d9d, ; 571: System.Linq.Expressions => 59
	i64 u0x996ceeb8a3da3d67, ; 572: System.Threading.Overlapped.dll => 141
	i64 u0x99a00ca5270c6878, ; 573: Xamarin.AndroidX.Navigation.Runtime => 248
	i64 u0x99cdc6d1f2d3a72f, ; 574: ko/Microsoft.Maui.Controls.resources.dll => 299
	i64 u0x9a01b1da98b6ee10, ; 575: Xamarin.AndroidX.Lifecycle.Runtime.dll => 236
	i64 u0x9a5ccc274fd6e6ee, ; 576: Jsr305Binding.dll => 270
	i64 u0x9ae6940b11c02876, ; 577: lib_Xamarin.AndroidX.Window.dll.so => 267
	i64 u0x9b211a749105beac, ; 578: System.Transactions.Local => 150
	i64 u0x9b8734714671022d, ; 579: System.Threading.Tasks.Dataflow.dll => 142
	i64 u0x9bc6aea27fbf034f, ; 580: lib_Xamarin.KotlinX.Coroutines.Core.dll.so => 279
	i64 u0x9bd8cc74558ad4c7, ; 581: Xamarin.KotlinX.AtomicFU => 276
	i64 u0x9c244ac7cda32d26, ; 582: System.Security.Cryptography.X509Certificates.dll => 126
	i64 u0x9c465f280cf43733, ; 583: lib_Xamarin.KotlinX.Coroutines.Android.dll.so => 278
	i64 u0x9c8f6872beab6408, ; 584: System.Xml.XPath.XDocument.dll => 160
	i64 u0x9c9ac1d95198ac57, ; 585: Newtonsoft.Json.Bson.dll => 192
	i64 u0x9ce01cf91101ae23, ; 586: System.Xml.XmlDocument => 162
	i64 u0x9d128180c81d7ce6, ; 587: Xamarin.AndroidX.CustomView.PoolingContainer => 219
	i64 u0x9d5dbcf5a48583fe, ; 588: lib_Xamarin.AndroidX.Activity.dll.so => 197
	i64 u0x9d74dee1a7725f34, ; 589: Microsoft.Extensions.Configuration.Abstractions.dll => 178
	i64 u0x9e4534b6adaf6e84, ; 590: nl/Microsoft.Maui.Controls.resources => 302
	i64 u0x9e4b95dec42769f7, ; 591: System.Diagnostics.Debug.dll => 26
	i64 u0x9eaf1efdf6f7267e, ; 592: Xamarin.AndroidX.Navigation.Common.dll => 246
	i64 u0x9ef542cf1f78c506, ; 593: Xamarin.AndroidX.Lifecycle.LiveData.Core => 233
	i64 u0xa00832eb975f56a8, ; 594: lib_System.Net.dll.so => 82
	i64 u0xa0ad78236b7b267f, ; 595: Xamarin.AndroidX.Window => 267
	i64 u0xa0d8259f4cc284ec, ; 596: lib_System.Security.Cryptography.dll.so => 127
	i64 u0xa0e17ca50c77a225, ; 597: lib_Xamarin.Google.Crypto.Tink.Android.dll.so => 271
	i64 u0xa0ff9b3e34d92f11, ; 598: lib_System.Resources.Writer.dll.so => 101
	i64 u0xa12fbfb4da97d9f3, ; 599: System.Threading.Timer.dll => 148
	i64 u0xa1440773ee9d341e, ; 600: Xamarin.Google.Android.Material => 269
	i64 u0xa1b9d7c27f47219f, ; 601: Xamarin.AndroidX.Navigation.UI.dll => 249
	i64 u0xa2572680829d2c7c, ; 602: System.IO.Pipelines.dll => 54
	i64 u0xa26597e57ee9c7f6, ; 603: System.Xml.XmlDocument.dll => 162
	i64 u0xa308401900e5bed3, ; 604: lib_mscorlib.dll.so => 167
	i64 u0xa395572e7da6c99d, ; 605: lib_System.Security.dll.so => 131
	i64 u0xa3e683f24b43af6f, ; 606: System.Dynamic.Runtime.dll => 37
	i64 u0xa4145becdee3dc4f, ; 607: Xamarin.AndroidX.VectorDrawable.Animated => 263
	i64 u0xa46aa1eaa214539b, ; 608: ko/Microsoft.Maui.Controls.resources => 299
	i64 u0xa4edc8f2ceae241a, ; 609: System.Data.Common.dll => 22
	i64 u0xa5494f40f128ce6a, ; 610: System.Runtime.Serialization.Formatters.dll => 112
	i64 u0xa54b74df83dce92b, ; 611: System.Reflection.DispatchProxy => 90
	i64 u0xa579ed010d7e5215, ; 612: Xamarin.AndroidX.DocumentFile => 220
	i64 u0xa5b7152421ed6d98, ; 613: lib_System.IO.FileSystem.Watcher.dll.so => 50
	i64 u0xa5c3844f17b822db, ; 614: lib_System.Linq.Parallel.dll.so => 60
	i64 u0xa5ce5c755bde8cb8, ; 615: lib_System.Security.Cryptography.Csp.dll.so => 122
	i64 u0xa5e599d1e0524750, ; 616: System.Numerics.Vectors.dll => 83
	i64 u0xa5f1ba49b85dd355, ; 617: System.Security.Cryptography.dll => 127
	i64 u0xa61975a5a37873ea, ; 618: lib_System.Xml.XmlSerializer.dll.so => 163
	i64 u0xa6593e21584384d2, ; 619: lib_Jsr305Binding.dll.so => 270
	i64 u0xa66cbee0130865f7, ; 620: lib_WindowsBase.dll.so => 166
	i64 u0xa67dbee13e1df9ca, ; 621: Xamarin.AndroidX.SavedState.dll => 254
	i64 u0xa684b098dd27b296, ; 622: lib_Xamarin.AndroidX.Security.SecurityCrypto.dll.so => 256
	i64 u0xa68a420042bb9b1f, ; 623: Xamarin.AndroidX.DrawerLayout.dll => 221
	i64 u0xa6d26156d1cacc7c, ; 624: Xamarin.Android.Glide.dll => 193
	i64 u0xa75386b5cb9595aa, ; 625: Xamarin.AndroidX.Lifecycle.Runtime.Android => 237
	i64 u0xa763fbb98df8d9fb, ; 626: lib_Microsoft.Win32.Primitives.dll.so => 4
	i64 u0xa78ce3745383236a, ; 627: Xamarin.AndroidX.Lifecycle.Common.Jvm => 231
	i64 u0xa7c31b56b4dc7b33, ; 628: hu/Microsoft.Maui.Controls.resources => 295
	i64 u0xa7eab29ed44b4e7a, ; 629: Mono.Android.Export => 170
	i64 u0xa8195217cbf017b7, ; 630: Microsoft.VisualBasic.Core => 2
	i64 u0xa859a95830f367ff, ; 631: lib_Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll.so => 242
	i64 u0xa8b52f21e0dbe690, ; 632: System.Runtime.Serialization.dll => 116
	i64 u0xa8ee4ed7de2efaee, ; 633: Xamarin.AndroidX.Annotation.dll => 199
	i64 u0xa95590e7c57438a4, ; 634: System.Configuration => 19
	i64 u0xaa2219c8e3449ff5, ; 635: Microsoft.Extensions.Logging.Abstractions => 182
	i64 u0xaa443ac34067eeef, ; 636: System.Private.Xml.dll => 89
	i64 u0xaa52de307ef5d1dd, ; 637: System.Net.Http => 65
	i64 u0xaa9a7b0214a5cc5c, ; 638: System.Diagnostics.StackTrace.dll => 30
	i64 u0xaaaf86367285a918, ; 639: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 180
	i64 u0xaaf84bb3f052a265, ; 640: el/Microsoft.Maui.Controls.resources => 288
	i64 u0xab9af77b5b67a0b8, ; 641: Xamarin.AndroidX.ConstraintLayout.Core => 213
	i64 u0xab9c1b2687d86b0b, ; 642: lib_System.Linq.Expressions.dll.so => 59
	i64 u0xac2af3fa195a15ce, ; 643: System.Runtime.Numerics => 111
	i64 u0xac5376a2a538dc10, ; 644: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 233
	i64 u0xac5acae88f60357e, ; 645: System.Diagnostics.Tools.dll => 32
	i64 u0xac79c7e46047ad98, ; 646: System.Security.Principal.Windows.dll => 128
	i64 u0xac98d31068e24591, ; 647: System.Xml.XDocument => 159
	i64 u0xacd46e002c3ccb97, ; 648: ro/Microsoft.Maui.Controls.resources => 306
	i64 u0xacdd9e4180d56dda, ; 649: Xamarin.AndroidX.Concurrent.Futures => 211
	i64 u0xacf42eea7ef9cd12, ; 650: System.Threading.Channels => 140
	i64 u0xad7e82ed3b0f16d0, ; 651: lib_Xamarin.AndroidX.DocumentFile.dll.so => 220
	i64 u0xad89c07347f1bad6, ; 652: nl/Microsoft.Maui.Controls.resources.dll => 302
	i64 u0xadbb53caf78a79d2, ; 653: System.Web.HttpUtility => 153
	i64 u0xadc90ab061a9e6e4, ; 654: System.ComponentModel.TypeConverter.dll => 17
	i64 u0xadca1b9030b9317e, ; 655: Xamarin.AndroidX.Collection.Ktx => 210
	i64 u0xadd8eda2edf396ad, ; 656: Xamarin.Android.Glide.GifDecoder => 196
	i64 u0xadf4cf30debbeb9a, ; 657: System.Net.ServicePoint.dll => 75
	i64 u0xadf511667bef3595, ; 658: System.Net.Security => 74
	i64 u0xae0aaa94fdcfce0f, ; 659: System.ComponentModel.EventBasedAsync.dll => 15
	i64 u0xae282bcd03739de7, ; 660: Java.Interop => 169
	i64 u0xae53579c90db1107, ; 661: System.ObjectModel.dll => 85
	i64 u0xaec7c0c7e2ed4575, ; 662: lib_Xamarin.KotlinX.AtomicFU.Jvm.dll.so => 277
	i64 u0xaeed36a5c09169bb, ; 663: lib_Models.dll.so => 317
	i64 u0xaf732d0b2193b8f5, ; 664: System.Security.Cryptography.OpenSsl.dll => 124
	i64 u0xafdb94dbccd9d11c, ; 665: Xamarin.AndroidX.Lifecycle.LiveData.dll => 232
	i64 u0xafe29f45095518e7, ; 666: lib_Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll.so => 243
	i64 u0xb03ae931fb25607e, ; 667: Xamarin.AndroidX.ConstraintLayout => 212
	i64 u0xb05cc42cd94c6d9d, ; 668: lib-sv-Microsoft.Maui.Controls.resources.dll.so => 309
	i64 u0xb0ac21bec8f428c5, ; 669: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.Android.dll => 239
	i64 u0xb0bb43dc52ea59f9, ; 670: System.Diagnostics.Tracing.dll => 34
	i64 u0xb1dd05401aa8ee63, ; 671: System.Security.AccessControl => 118
	i64 u0xb220631954820169, ; 672: System.Text.RegularExpressions => 139
	i64 u0xb2376e1dbf8b4ed7, ; 673: System.Security.Cryptography.Csp => 122
	i64 u0xb2a1959fe95c5402, ; 674: lib_System.Runtime.InteropServices.JavaScript.dll.so => 106
	i64 u0xb2a3f67f3bf29fce, ; 675: da/Microsoft.Maui.Controls.resources => 286
	i64 u0xb3874072ee0ecf8c, ; 676: Xamarin.AndroidX.VectorDrawable.Animated.dll => 263
	i64 u0xb3f0a0fcda8d3ebc, ; 677: Xamarin.AndroidX.CardView => 207
	i64 u0xb46be1aa6d4fff93, ; 678: hi/Microsoft.Maui.Controls.resources => 293
	i64 u0xb477491be13109d8, ; 679: ar/Microsoft.Maui.Controls.resources => 283
	i64 u0xb4bd7015ecee9d86, ; 680: System.IO.Pipelines => 54
	i64 u0xb4c53d9749c5f226, ; 681: lib_System.IO.FileSystem.AccessControl.dll.so => 47
	i64 u0xb4ff710863453fda, ; 682: System.Diagnostics.FileVersionInfo.dll => 28
	i64 u0xb5c38bf497a4cfe2, ; 683: lib_System.Threading.Tasks.dll.so => 145
	i64 u0xb5c7fcdafbc67ee4, ; 684: Microsoft.Extensions.Logging.Abstractions.dll => 182
	i64 u0xb5ea31d5244c6626, ; 685: System.Threading.ThreadPool.dll => 147
	i64 u0xb7212c4683a94afe, ; 686: System.Drawing.Primitives => 35
	i64 u0xb7b7753d1f319409, ; 687: sv/Microsoft.Maui.Controls.resources => 309
	i64 u0xb81a2c6e0aee50fe, ; 688: lib_System.Private.CoreLib.dll.so => 173
	i64 u0xb8b0a9b3dfbc5cb7, ; 689: Xamarin.AndroidX.Window.Extensions.Core.Core => 268
	i64 u0xb8c60af47c08d4da, ; 690: System.Net.ServicePoint => 75
	i64 u0xb8e68d20aad91196, ; 691: lib_System.Xml.XPath.dll.so => 161
	i64 u0xb8f24ab5681c3dc5, ; 692: Docker.DotNet.dll => 174
	i64 u0xb9185c33a1643eed, ; 693: Microsoft.CSharp.dll => 1
	i64 u0xb9b8001adf4ed7cc, ; 694: lib_Xamarin.AndroidX.SlidingPaneLayout.dll.so => 257
	i64 u0xb9f64d3b230def68, ; 695: lib-pt-Microsoft.Maui.Controls.resources.dll.so => 305
	i64 u0xb9fc3c8a556e3691, ; 696: ja/Microsoft.Maui.Controls.resources => 298
	i64 u0xba4670aa94a2b3c6, ; 697: lib_System.Xml.XDocument.dll.so => 159
	i64 u0xba48785529705af9, ; 698: System.Collections.dll => 12
	i64 u0xba965b8c86359996, ; 699: lib_System.Windows.dll.so => 155
	i64 u0xbb286883bc35db36, ; 700: System.Transactions.dll => 151
	i64 u0xbb65706fde942ce3, ; 701: System.Net.Sockets => 76
	i64 u0xbba28979413cad9e, ; 702: lib_System.Runtime.CompilerServices.VisualC.dll.so => 103
	i64 u0xbbd180354b67271a, ; 703: System.Runtime.Serialization.Formatters => 112
	i64 u0xbc260cdba33291a3, ; 704: Xamarin.AndroidX.Arch.Core.Common.dll => 204
	i64 u0xbd0e2c0d55246576, ; 705: System.Net.Http.dll => 65
	i64 u0xbd3fbd85b9e1cb29, ; 706: lib_System.Net.HttpListener.dll.so => 66
	i64 u0xbd437a2cdb333d0d, ; 707: Xamarin.AndroidX.ViewPager2 => 266
	i64 u0xbd4f572d2bd0a789, ; 708: System.IO.Compression.ZipFile.dll => 45
	i64 u0xbd5d0b88d3d647a5, ; 709: lib_Xamarin.AndroidX.Browser.dll.so => 206
	i64 u0xbd877b14d0b56392, ; 710: System.Runtime.Intrinsics.dll => 109
	i64 u0xbe65a49036345cf4, ; 711: lib_System.Buffers.dll.so => 7
	i64 u0xbea82a18727b8d18, ; 712: lib_System.Net.Http.Formatting.dll.so => 176
	i64 u0xbee38d4a88835966, ; 713: Xamarin.AndroidX.AppCompat.AppCompatResources => 203
	i64 u0xbef9919db45b4ca7, ; 714: System.IO.Pipes.AccessControl => 55
	i64 u0xbf0fa68611139208, ; 715: lib_Xamarin.AndroidX.Annotation.dll.so => 199
	i64 u0xbfc1e1fb3095f2b3, ; 716: lib_System.Net.Http.Json.dll.so => 64
	i64 u0xc040a4ab55817f58, ; 717: ar/Microsoft.Maui.Controls.resources.dll => 283
	i64 u0xc07cadab29efeba0, ; 718: Xamarin.AndroidX.Core.Core.Ktx.dll => 216
	i64 u0xc0d928351ab5ca77, ; 719: System.Console.dll => 20
	i64 u0xc0f5a221a9383aea, ; 720: System.Runtime.Intrinsics => 109
	i64 u0xc111030af54d7191, ; 721: System.Resources.Writer => 101
	i64 u0xc12b8b3afa48329c, ; 722: lib_System.Linq.dll.so => 62
	i64 u0xc183ca0b74453aa9, ; 723: lib_System.Threading.Tasks.Dataflow.dll.so => 142
	i64 u0xc1ff9ae3cdb6e1e6, ; 724: Xamarin.AndroidX.Activity.dll => 197
	i64 u0xc26c064effb1dea9, ; 725: System.Buffers.dll => 7
	i64 u0xc28c50f32f81cc73, ; 726: ja/Microsoft.Maui.Controls.resources.dll => 298
	i64 u0xc2902f6cf5452577, ; 727: lib_Mono.Android.Export.dll.so => 170
	i64 u0xc2a3bca55b573141, ; 728: System.IO.FileSystem.Watcher => 50
	i64 u0xc2bcfec99f69365e, ; 729: Xamarin.AndroidX.ViewPager2.dll => 266
	i64 u0xc30b52815b58ac2c, ; 730: lib_System.Runtime.Serialization.Xml.dll.so => 115
	i64 u0xc36d7d89c652f455, ; 731: System.Threading.Overlapped => 141
	i64 u0xc396b285e59e5493, ; 732: GoogleGson.dll => 175
	i64 u0xc3c86c1e5e12f03d, ; 733: WindowsBase => 166
	i64 u0xc421b61fd853169d, ; 734: lib_System.Net.WebSockets.Client.dll.so => 80
	i64 u0xc463e077917aa21d, ; 735: System.Runtime.Serialization.Json => 113
	i64 u0xc4d3858ed4d08512, ; 736: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 243
	i64 u0xc50fded0ded1418c, ; 737: lib_System.ComponentModel.TypeConverter.dll.so => 17
	i64 u0xc519125d6bc8fb11, ; 738: lib_System.Net.Requests.dll.so => 73
	i64 u0xc5293b19e4dc230e, ; 739: Xamarin.AndroidX.Navigation.Fragment => 247
	i64 u0xc5325b2fcb37446f, ; 740: lib_System.Private.Xml.dll.so => 89
	i64 u0xc535cb9a21385d9b, ; 741: lib_Xamarin.Android.Glide.DiskLruCache.dll.so => 195
	i64 u0xc5a0f4b95a699af7, ; 742: lib_System.Private.Uri.dll.so => 87
	i64 u0xc5cdcd5b6277579e, ; 743: lib_System.Security.Cryptography.Algorithms.dll.so => 120
	i64 u0xc5ec286825cb0bf4, ; 744: Xamarin.AndroidX.Tracing.Tracing => 260
	i64 u0xc6706bc8aa7fe265, ; 745: Xamarin.AndroidX.Annotation.Jvm => 201
	i64 u0xc7c01e7d7c93a110, ; 746: System.Text.Encoding.Extensions.dll => 135
	i64 u0xc7ce851898a4548e, ; 747: lib_System.Web.HttpUtility.dll.so => 153
	i64 u0xc809d4089d2556b2, ; 748: System.Runtime.InteropServices.JavaScript.dll => 106
	i64 u0xc858a28d9ee5a6c5, ; 749: lib_System.Collections.Specialized.dll.so => 11
	i64 u0xc8ac7c6bf1c2ec51, ; 750: System.Reflection.DispatchProxy.dll => 90
	i64 u0xc9c62c8f354ac568, ; 751: lib_System.Diagnostics.TextWriterTraceListener.dll.so => 31
	i64 u0xca3a723e7342c5b6, ; 752: lib-tr-Microsoft.Maui.Controls.resources.dll.so => 311
	i64 u0xca5801070d9fccfb, ; 753: System.Text.Encoding => 136
	i64 u0xcab3493c70141c2d, ; 754: pl/Microsoft.Maui.Controls.resources => 303
	i64 u0xcacfddc9f7c6de76, ; 755: ro/Microsoft.Maui.Controls.resources.dll => 306
	i64 u0xcadbc92899a777f0, ; 756: Xamarin.AndroidX.Startup.StartupRuntime => 258
	i64 u0xcba1cb79f45292b5, ; 757: Xamarin.Android.Glide.GifDecoder.dll => 196
	i64 u0xcba6056f87ed95e8, ; 758: System.Net.Http.Formatting.dll => 176
	i64 u0xcbb5f80c7293e696, ; 759: lib_System.Globalization.Calendars.dll.so => 40
	i64 u0xcbd4fdd9cef4a294, ; 760: lib__Microsoft.Android.Resource.Designer.dll.so => 319
	i64 u0xcc15da1e07bbd994, ; 761: Xamarin.AndroidX.SlidingPaneLayout => 257
	i64 u0xcc2876b32ef2794c, ; 762: lib_System.Text.RegularExpressions.dll.so => 139
	i64 u0xcc5c3bb714c4561e, ; 763: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 280
	i64 u0xcc76886e09b88260, ; 764: Xamarin.KotlinX.Serialization.Core.Jvm.dll => 282
	i64 u0xcc9fa2923aa1c9ef, ; 765: System.Diagnostics.Contracts.dll => 25
	i64 u0xccf25c4b634ccd3a, ; 766: zh-Hans/Microsoft.Maui.Controls.resources.dll => 315
	i64 u0xcd10a42808629144, ; 767: System.Net.Requests => 73
	i64 u0xcdca1b920e9f53ba, ; 768: Xamarin.AndroidX.Interpolator => 228
	i64 u0xcdd0c48b6937b21c, ; 769: Xamarin.AndroidX.SwipeRefreshLayout => 259
	i64 u0xcef65cbf0b19b1e3, ; 770: Newtonsoft.Json.Bson => 192
	i64 u0xcf23d8093f3ceadf, ; 771: System.Diagnostics.DiagnosticSource.dll => 27
	i64 u0xcf5ff6b6b2c4c382, ; 772: System.Net.Mail.dll => 67
	i64 u0xcf8fc898f98b0d34, ; 773: System.Private.Xml.Linq => 88
	i64 u0xd04b5f59ed596e31, ; 774: System.Reflection.Metadata.dll => 95
	i64 u0xd063299fcfc0c93f, ; 775: lib_System.Runtime.Serialization.Json.dll.so => 113
	i64 u0xd0de8a113e976700, ; 776: System.Diagnostics.TextWriterTraceListener => 31
	i64 u0xd0fc33d5ae5d4cb8, ; 777: System.Runtime.Extensions => 104
	i64 u0xd1194e1d8a8de83c, ; 778: lib_Xamarin.AndroidX.Lifecycle.Common.Jvm.dll.so => 231
	i64 u0xd12beacdfc14f696, ; 779: System.Dynamic.Runtime => 37
	i64 u0xd198e7ce1b6a8344, ; 780: System.Net.Quic.dll => 72
	i64 u0xd3144156a3727ebe, ; 781: Xamarin.Google.Guava.ListenableFuture => 273
	i64 u0xd333d0af9e423810, ; 782: System.Runtime.InteropServices => 108
	i64 u0xd33a415cb4278969, ; 783: System.Security.Cryptography.Encoding.dll => 123
	i64 u0xd3426d966bb704f5, ; 784: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 203
	i64 u0xd3651b6fc3125825, ; 785: System.Private.Uri.dll => 87
	i64 u0xd373685349b1fe8b, ; 786: Microsoft.Extensions.Logging.dll => 181
	i64 u0xd3801faafafb7698, ; 787: System.Private.DataContractSerialization.dll => 86
	i64 u0xd3e4c8d6a2d5d470, ; 788: it/Microsoft.Maui.Controls.resources => 297
	i64 u0xd3edcc1f25459a50, ; 789: System.Reflection.Emit => 93
	i64 u0xd4645626dffec99d, ; 790: lib_Microsoft.Extensions.DependencyInjection.Abstractions.dll.so => 180
	i64 u0xd4fa0abb79079ea9, ; 791: System.Security.Principal.dll => 129
	i64 u0xd530ec12ef3f93d6, ; 792: Models.dll => 317
	i64 u0xd5507e11a2b2839f, ; 793: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 243
	i64 u0xd5d04bef8478ea19, ; 794: Xamarin.AndroidX.Tracing.Tracing.dll => 260
	i64 u0xd60815f26a12e140, ; 795: Microsoft.Extensions.Logging.Debug.dll => 183
	i64 u0xd6694f8359737e4e, ; 796: Xamarin.AndroidX.SavedState => 254
	i64 u0xd6949e129339eae5, ; 797: lib_Xamarin.AndroidX.Core.Core.Ktx.dll.so => 216
	i64 u0xd6d21782156bc35b, ; 798: Xamarin.AndroidX.SwipeRefreshLayout.dll => 259
	i64 u0xd6de019f6af72435, ; 799: Xamarin.AndroidX.ConstraintLayout.Core.dll => 213
	i64 u0xd70956d1e6deefb9, ; 800: Jsr305Binding => 270
	i64 u0xd72329819cbbbc44, ; 801: lib_Microsoft.Extensions.Configuration.Abstractions.dll.so => 178
	i64 u0xd72c760af136e863, ; 802: System.Xml.XmlSerializer.dll => 163
	i64 u0xd753f071e44c2a03, ; 803: lib_System.Security.SecureString.dll.so => 130
	i64 u0xd7b3764ada9d341d, ; 804: lib_Microsoft.Extensions.Logging.Abstractions.dll.so => 182
	i64 u0xd7f0088bc5ad71f2, ; 805: Xamarin.AndroidX.VersionedParcelable => 264
	i64 u0xd8fb25e28ae30a12, ; 806: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 251
	i64 u0xda1dfa4c534a9251, ; 807: Microsoft.Extensions.DependencyInjection => 179
	i64 u0xdad05a11827959a3, ; 808: System.Collections.NonGeneric.dll => 10
	i64 u0xdaefdfe71aa53cf9, ; 809: System.IO.FileSystem.Primitives => 49
	i64 u0xdb5383ab5865c007, ; 810: lib-vi-Microsoft.Maui.Controls.resources.dll.so => 313
	i64 u0xdb58816721c02a59, ; 811: lib_System.Reflection.Emit.ILGeneration.dll.so => 91
	i64 u0xdbeda89f832aa805, ; 812: vi/Microsoft.Maui.Controls.resources.dll => 313
	i64 u0xdbf2a779fbc3ac31, ; 813: System.Transactions.Local.dll => 150
	i64 u0xdbf9607a441b4505, ; 814: System.Linq => 62
	i64 u0xdbfc90157a0de9b0, ; 815: lib_System.Text.Encoding.dll.so => 136
	i64 u0xdc75032002d1a212, ; 816: lib_System.Transactions.Local.dll.so => 150
	i64 u0xdca8be7403f92d4f, ; 817: lib_System.Linq.Queryable.dll.so => 61
	i64 u0xdce2c53525640bf3, ; 818: Microsoft.Extensions.Logging => 181
	i64 u0xdd2b722d78ef5f43, ; 819: System.Runtime.dll => 117
	i64 u0xdd67031857c72f96, ; 820: lib_System.Text.Encodings.Web.dll.so => 137
	i64 u0xdd92e229ad292030, ; 821: System.Numerics.dll => 84
	i64 u0xdddcdd701e911af1, ; 822: lib_Xamarin.AndroidX.Legacy.Support.Core.Utils.dll.so => 229
	i64 u0xdde30e6b77aa6f6c, ; 823: lib-zh-Hans-Microsoft.Maui.Controls.resources.dll.so => 315
	i64 u0xde110ae80fa7c2e2, ; 824: System.Xml.XDocument.dll => 159
	i64 u0xde4726fcdf63a198, ; 825: Xamarin.AndroidX.Transition => 261
	i64 u0xde572c2b2fb32f93, ; 826: lib_System.Threading.Tasks.Extensions.dll.so => 143
	i64 u0xde8769ebda7d8647, ; 827: hr/Microsoft.Maui.Controls.resources.dll => 294
	i64 u0xdee075f3477ef6be, ; 828: Xamarin.AndroidX.ExifInterface.dll => 225
	i64 u0xdf4b773de8fb1540, ; 829: System.Net.dll => 82
	i64 u0xdfa254ebb4346068, ; 830: System.Net.Ping => 70
	i64 u0xe0142572c095a480, ; 831: Xamarin.AndroidX.AppCompat.dll => 202
	i64 u0xe021eaa401792a05, ; 832: System.Text.Encoding.dll => 136
	i64 u0xe02f89350ec78051, ; 833: Xamarin.AndroidX.CoordinatorLayout.dll => 214
	i64 u0xe0496b9d65ef5474, ; 834: Xamarin.Android.Glide.DiskLruCache.dll => 195
	i64 u0xe10b760bb1462e7a, ; 835: lib_System.Security.Cryptography.Primitives.dll.so => 125
	i64 u0xe192a588d4410686, ; 836: lib_System.IO.Pipelines.dll.so => 54
	i64 u0xe1a08bd3fa539e0d, ; 837: System.Runtime.Loader => 110
	i64 u0xe1a77eb8831f7741, ; 838: System.Security.SecureString.dll => 130
	i64 u0xe1ace591eebb7293, ; 839: lib_Newtonsoft.Json.Bson.dll.so => 192
	i64 u0xe1b52f9f816c70ef, ; 840: System.Private.Xml.Linq.dll => 88
	i64 u0xe1e199c8ab02e356, ; 841: System.Data.DataSetExtensions.dll => 23
	i64 u0xe1ecfdb7fff86067, ; 842: System.Net.Security.dll => 74
	i64 u0xe2252a80fe853de4, ; 843: lib_System.Security.Principal.dll.so => 129
	i64 u0xe22fa4c9c645db62, ; 844: System.Diagnostics.TextWriterTraceListener.dll => 31
	i64 u0xe2420585aeceb728, ; 845: System.Net.Requests.dll => 73
	i64 u0xe26692647e6bcb62, ; 846: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 238
	i64 u0xe29b73bc11392966, ; 847: lib-id-Microsoft.Maui.Controls.resources.dll.so => 296
	i64 u0xe2ad448dee50fbdf, ; 848: System.Xml.Serialization => 158
	i64 u0xe2d920f978f5d85c, ; 849: System.Data.DataSetExtensions => 23
	i64 u0xe2e426c7714fa0bc, ; 850: Microsoft.Win32.Primitives.dll => 4
	i64 u0xe332bacb3eb4a806, ; 851: Mono.Android.Export.dll => 170
	i64 u0xe3811d68d4fe8463, ; 852: pt-BR/Microsoft.Maui.Controls.resources.dll => 304
	i64 u0xe3b7cbae5ad66c75, ; 853: lib_System.Security.Cryptography.Encoding.dll.so => 123
	i64 u0xe494f7ced4ecd10a, ; 854: hu/Microsoft.Maui.Controls.resources.dll => 295
	i64 u0xe4a9b1e40d1e8917, ; 855: lib-fi-Microsoft.Maui.Controls.resources.dll.so => 290
	i64 u0xe4f74a0b5bf9703f, ; 856: System.Runtime.Serialization.Primitives => 114
	i64 u0xe5434e8a119ceb69, ; 857: lib_Mono.Android.dll.so => 172
	i64 u0xe55703b9ce5c038a, ; 858: System.Diagnostics.Tools => 32
	i64 u0xe57013c8afc270b5, ; 859: Microsoft.VisualBasic => 3
	i64 u0xe62913cc36bc07ec, ; 860: System.Xml.dll => 164
	i64 u0xe7bea09c4900a191, ; 861: Xamarin.AndroidX.VectorDrawable.dll => 262
	i64 u0xe7e03cc18dcdeb49, ; 862: lib_System.Diagnostics.StackTrace.dll.so => 30
	i64 u0xe7e147ff99a7a380, ; 863: lib_System.Configuration.dll.so => 19
	i64 u0xe86b0df4ba9e5db8, ; 864: lib_Xamarin.AndroidX.Lifecycle.Runtime.Android.dll.so => 237
	i64 u0xe896622fe0902957, ; 865: System.Reflection.Emit.dll => 93
	i64 u0xe89a2a9ef110899b, ; 866: System.Drawing.dll => 36
	i64 u0xe8c5f8c100b5934b, ; 867: Microsoft.Win32.Registry => 5
	i64 u0xe957c3976986ab72, ; 868: lib_Xamarin.AndroidX.Window.Extensions.Core.Core.dll.so => 268
	i64 u0xe98163eb702ae5c5, ; 869: Xamarin.AndroidX.Arch.Core.Runtime => 205
	i64 u0xe994f23ba4c143e5, ; 870: Xamarin.KotlinX.Coroutines.Android => 278
	i64 u0xe9b9c8c0458fd92a, ; 871: System.Windows => 155
	i64 u0xe9d166d87a7f2bdb, ; 872: lib_Xamarin.AndroidX.Startup.StartupRuntime.dll.so => 258
	i64 u0xea5a4efc2ad81d1b, ; 873: Xamarin.Google.ErrorProne.Annotations => 272
	i64 u0xeb2313fe9d65b785, ; 874: Xamarin.AndroidX.ConstraintLayout.dll => 212
	i64 u0xeb6e275e78cb8d42, ; 875: Xamarin.AndroidX.LocalBroadcastManager.dll => 245
	i64 u0xed19c616b3fcb7eb, ; 876: Xamarin.AndroidX.VersionedParcelable.dll => 264
	i64 u0xedc4817167106c23, ; 877: System.Net.Sockets.dll => 76
	i64 u0xedc632067fb20ff3, ; 878: System.Memory.dll => 63
	i64 u0xedc8e4ca71a02a8b, ; 879: Xamarin.AndroidX.Navigation.Runtime.dll => 248
	i64 u0xee244de7fb40ce81, ; 880: Models => 317
	i64 u0xee81f5b3f1c4f83b, ; 881: System.Threading.ThreadPool => 147
	i64 u0xeeb7ebb80150501b, ; 882: lib_Xamarin.AndroidX.Collection.Jvm.dll.so => 209
	i64 u0xeefc635595ef57f0, ; 883: System.Security.Cryptography.Cng => 121
	i64 u0xef03b1b5a04e9709, ; 884: System.Text.Encoding.CodePages.dll => 134
	i64 u0xef432781d5667f61, ; 885: Xamarin.AndroidX.Print => 250
	i64 u0xef602c523fe2e87a, ; 886: lib_Xamarin.Google.Guava.ListenableFuture.dll.so => 273
	i64 u0xef72742e1bcca27a, ; 887: Microsoft.Maui.Essentials.dll => 189
	i64 u0xefd1e0c4e5c9b371, ; 888: System.Resources.ResourceManager.dll => 100
	i64 u0xefe8f8d5ed3c72ea, ; 889: System.Formats.Tar.dll => 39
	i64 u0xefec0b7fdc57ec42, ; 890: Xamarin.AndroidX.Activity => 197
	i64 u0xf00c29406ea45e19, ; 891: es/Microsoft.Maui.Controls.resources.dll => 289
	i64 u0xf09e47b6ae914f6e, ; 892: System.Net.NameResolution => 68
	i64 u0xf0ac2b489fed2e35, ; 893: lib_System.Diagnostics.Debug.dll.so => 26
	i64 u0xf0bb49dadd3a1fe1, ; 894: lib_System.Net.ServicePoint.dll.so => 75
	i64 u0xf0de2537ee19c6ca, ; 895: lib_System.Net.WebHeaderCollection.dll.so => 78
	i64 u0xf1138779fa181c68, ; 896: lib_Xamarin.AndroidX.Lifecycle.Runtime.dll.so => 236
	i64 u0xf11b621fc87b983f, ; 897: Microsoft.Maui.Controls.Xaml.dll => 187
	i64 u0xf161f4f3c3b7e62c, ; 898: System.Data => 24
	i64 u0xf16eb650d5a464bc, ; 899: System.ValueTuple => 152
	i64 u0xf1c4b4005493d871, ; 900: System.Formats.Asn1.dll => 38
	i64 u0xf238bd79489d3a96, ; 901: lib-nl-Microsoft.Maui.Controls.resources.dll.so => 302
	i64 u0xf2feea356ba760af, ; 902: Xamarin.AndroidX.Arch.Core.Runtime.dll => 205
	i64 u0xf300e085f8acd238, ; 903: lib_System.ServiceProcess.dll.so => 133
	i64 u0xf34e52b26e7e059d, ; 904: System.Runtime.CompilerServices.VisualC.dll => 103
	i64 u0xf37221fda4ef8830, ; 905: lib_Xamarin.Google.Android.Material.dll.so => 269
	i64 u0xf3ad9b8fb3eefd12, ; 906: lib_System.IO.UnmanagedMemoryStream.dll.so => 57
	i64 u0xf3ddfe05336abf29, ; 907: System => 165
	i64 u0xf408654b2a135055, ; 908: System.Reflection.Emit.ILGeneration.dll => 91
	i64 u0xf4103170a1de5bd0, ; 909: System.Linq.Queryable.dll => 61
	i64 u0xf42d20c23173d77c, ; 910: lib_System.ServiceModel.Web.dll.so => 132
	i64 u0xf4c1dd70a5496a17, ; 911: System.IO.Compression => 46
	i64 u0xf4ecf4b9afc64781, ; 912: System.ServiceProcess.dll => 133
	i64 u0xf4eeeaa566e9b970, ; 913: lib_Xamarin.AndroidX.CustomView.PoolingContainer.dll.so => 219
	i64 u0xf518f63ead11fcd1, ; 914: System.Threading.Tasks => 145
	i64 u0xf5fc7602fe27b333, ; 915: System.Net.WebHeaderCollection => 78
	i64 u0xf6077741019d7428, ; 916: Xamarin.AndroidX.CoordinatorLayout => 214
	i64 u0xf6742cbf457c450b, ; 917: Xamarin.AndroidX.Lifecycle.Runtime.Android.dll => 237
	i64 u0xf70c0a7bf8ccf5af, ; 918: System.Web => 154
	i64 u0xf77b20923f07c667, ; 919: de/Microsoft.Maui.Controls.resources.dll => 287
	i64 u0xf7e2cac4c45067b3, ; 920: lib_System.Numerics.Vectors.dll.so => 83
	i64 u0xf7e74930e0e3d214, ; 921: zh-HK/Microsoft.Maui.Controls.resources.dll => 314
	i64 u0xf7fa0bf77fe677cc, ; 922: Newtonsoft.Json.dll => 191
	i64 u0xf84773b5c81e3cef, ; 923: lib-uk-Microsoft.Maui.Controls.resources.dll.so => 312
	i64 u0xf8aac5ea82de1348, ; 924: System.Linq.Queryable => 61
	i64 u0xf8b77539b362d3ba, ; 925: lib_System.Reflection.Primitives.dll.so => 96
	i64 u0xf8e045dc345b2ea3, ; 926: lib_Xamarin.AndroidX.RecyclerView.dll.so => 252
	i64 u0xf915dc29808193a1, ; 927: System.Web.HttpUtility.dll => 153
	i64 u0xf96c777a2a0686f4, ; 928: hi/Microsoft.Maui.Controls.resources.dll => 293
	i64 u0xf9be54c8bcf8ff3b, ; 929: System.Security.AccessControl.dll => 118
	i64 u0xf9eec5bb3a6aedc6, ; 930: Microsoft.Extensions.Options => 184
	i64 u0xfa0e82300e67f913, ; 931: lib_System.AppContext.dll.so => 6
	i64 u0xfa2fdb27e8a2c8e8, ; 932: System.ComponentModel.EventBasedAsync => 15
	i64 u0xfa3f278f288b0e84, ; 933: lib_System.Net.Security.dll.so => 74
	i64 u0xfa5ed7226d978949, ; 934: lib-ar-Microsoft.Maui.Controls.resources.dll.so => 283
	i64 u0xfa645d91e9fc4cba, ; 935: System.Threading.Thread => 146
	i64 u0xfad4d2c770e827f9, ; 936: lib_System.IO.IsolatedStorage.dll.so => 52
	i64 u0xfb06dd2338e6f7c4, ; 937: System.Net.Ping.dll => 70
	i64 u0xfb087abe5365e3b7, ; 938: lib_System.Data.DataSetExtensions.dll.so => 23
	i64 u0xfb846e949baff5ea, ; 939: System.Xml.Serialization.dll => 158
	i64 u0xfbad3e4ce4b98145, ; 940: System.Security.Cryptography.X509Certificates => 126
	i64 u0xfbf0a31c9fc34bc4, ; 941: lib_System.Net.Http.dll.so => 65
	i64 u0xfc61ddcf78dd1f54, ; 942: Xamarin.AndroidX.LocalBroadcastManager => 245
	i64 u0xfc6b7527cc280b3f, ; 943: lib_System.Runtime.Serialization.Formatters.dll.so => 112
	i64 u0xfc719aec26adf9d9, ; 944: Xamarin.AndroidX.Navigation.Fragment.dll => 247
	i64 u0xfc82690c2fe2735c, ; 945: Xamarin.AndroidX.Lifecycle.Process.dll => 235
	i64 u0xfc93fc307d279893, ; 946: System.IO.Pipes.AccessControl.dll => 55
	i64 u0xfcd302092ada6328, ; 947: System.IO.MemoryMappedFiles.dll => 53
	i64 u0xfd22f00870e40ae0, ; 948: lib_Xamarin.AndroidX.DrawerLayout.dll.so => 221
	i64 u0xfd49b3c1a76e2748, ; 949: System.Runtime.InteropServices.RuntimeInformation => 107
	i64 u0xfd536c702f64dc47, ; 950: System.Text.Encoding.Extensions => 135
	i64 u0xfd583f7657b6a1cb, ; 951: Xamarin.AndroidX.Fragment => 226
	i64 u0xfd8dd91a2c26bd5d, ; 952: Xamarin.AndroidX.Lifecycle.Runtime => 236
	i64 u0xfda36abccf05cf5c, ; 953: System.Net.WebSockets.Client => 80
	i64 u0xfddbe9695626a7f5, ; 954: Xamarin.AndroidX.Lifecycle.Common => 230
	i64 u0xfeae9952cf03b8cb, ; 955: tr/Microsoft.Maui.Controls.resources => 311
	i64 u0xfebe1950717515f9, ; 956: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 234
	i64 u0xff270a55858bac8d, ; 957: System.Security.Principal => 129
	i64 u0xff9b54613e0d2cc8, ; 958: System.Net.Http.Json => 64
	i64 u0xffdb7a971be4ec73 ; 959: System.ValueTuple.dll => 152
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [960 x i32] [
	i32 42, i32 279, i32 259, i32 13, i32 248, i32 105, i32 171, i32 48,
	i32 202, i32 7, i32 86, i32 307, i32 285, i32 313, i32 222, i32 71,
	i32 252, i32 12, i32 188, i32 102, i32 314, i32 156, i32 19, i32 227,
	i32 209, i32 161, i32 224, i32 262, i32 167, i32 307, i32 10, i32 183,
	i32 263, i32 96, i32 219, i32 221, i32 13, i32 184, i32 10, i32 127,
	i32 95, i32 140, i32 39, i32 308, i32 282, i32 265, i32 304, i32 172,
	i32 196, i32 5, i32 189, i32 67, i32 256, i32 130, i32 255, i32 223,
	i32 68, i32 210, i32 66, i32 57, i32 218, i32 52, i32 43, i32 125,
	i32 67, i32 81, i32 238, i32 158, i32 92, i32 99, i32 252, i32 141,
	i32 151, i32 206, i32 291, i32 162, i32 169, i32 292, i32 180, i32 81,
	i32 210, i32 4, i32 5, i32 51, i32 101, i32 56, i32 120, i32 98,
	i32 168, i32 118, i32 279, i32 21, i32 295, i32 137, i32 97, i32 282,
	i32 77, i32 301, i32 250, i32 258, i32 119, i32 8, i32 165, i32 310,
	i32 70, i32 195, i32 239, i32 253, i32 171, i32 145, i32 40, i32 256,
	i32 47, i32 30, i32 249, i32 299, i32 144, i32 184, i32 163, i32 28,
	i32 84, i32 260, i32 77, i32 43, i32 29, i32 42, i32 103, i32 117,
	i32 200, i32 45, i32 91, i32 310, i32 56, i32 148, i32 146, i32 100,
	i32 49, i32 318, i32 20, i32 215, i32 114, i32 193, i32 291, i32 271,
	i32 275, i32 185, i32 94, i32 58, i32 296, i32 294, i32 81, i32 271,
	i32 169, i32 26, i32 71, i32 251, i32 225, i32 312, i32 69, i32 318,
	i32 33, i32 290, i32 14, i32 139, i32 38, i32 316, i32 211, i32 303,
	i32 134, i32 92, i32 88, i32 149, i32 309, i32 24, i32 138, i32 57,
	i32 51, i32 288, i32 29, i32 157, i32 34, i32 164, i32 226, i32 52,
	i32 319, i32 267, i32 90, i32 207, i32 35, i32 291, i32 157, i32 9,
	i32 289, i32 76, i32 55, i32 188, i32 285, i32 186, i32 13, i32 266,
	i32 177, i32 204, i32 109, i32 242, i32 32, i32 104, i32 84, i32 92,
	i32 53, i32 96, i32 274, i32 58, i32 9, i32 102, i32 218, i32 68,
	i32 265, i32 284, i32 191, i32 125, i32 253, i32 116, i32 176, i32 135,
	i32 126, i32 106, i32 275, i32 131, i32 206, i32 273, i32 147, i32 156,
	i32 227, i32 215, i32 222, i32 253, i32 97, i32 24, i32 174, i32 257,
	i32 143, i32 250, i32 246, i32 3, i32 167, i32 203, i32 100, i32 161,
	i32 99, i32 0, i32 25, i32 93, i32 168, i32 172, i32 198, i32 3,
	i32 303, i32 224, i32 1, i32 114, i32 275, i32 227, i32 235, i32 33,
	i32 6, i32 307, i32 156, i32 305, i32 53, i32 229, i32 85, i32 264,
	i32 249, i32 44, i32 234, i32 104, i32 47, i32 138, i32 64, i32 244,
	i32 69, i32 80, i32 59, i32 89, i32 154, i32 204, i32 133, i32 110,
	i32 297, i32 244, i32 251, i32 171, i32 134, i32 140, i32 40, i32 174,
	i32 284, i32 186, i32 60, i32 241, i32 79, i32 25, i32 36, i32 99,
	i32 238, i32 71, i32 22, i32 215, i32 190, i32 308, i32 121, i32 69,
	i32 107, i32 314, i32 245, i32 119, i32 117, i32 230, i32 231, i32 11,
	i32 2, i32 124, i32 115, i32 142, i32 41, i32 87, i32 0, i32 199,
	i32 173, i32 27, i32 148, i32 298, i32 179, i32 272, i32 198, i32 1,
	i32 200, i32 44, i32 214, i32 149, i32 229, i32 18, i32 86, i32 286,
	i32 41, i32 234, i32 208, i32 239, i32 94, i32 181, i32 28, i32 41,
	i32 78, i32 223, i32 211, i32 144, i32 108, i32 209, i32 11, i32 105,
	i32 137, i32 16, i32 122, i32 66, i32 157, i32 22, i32 288, i32 281,
	i32 102, i32 179, i32 280, i32 63, i32 58, i32 187, i32 287, i32 110,
	i32 173, i32 278, i32 9, i32 269, i32 120, i32 98, i32 105, i32 242,
	i32 186, i32 111, i32 201, i32 49, i32 20, i32 241, i32 217, i32 72,
	i32 213, i32 155, i32 39, i32 286, i32 35, i32 276, i32 38, i32 292,
	i32 268, i32 108, i32 301, i32 21, i32 274, i32 240, i32 190, i32 15,
	i32 185, i32 79, i32 79, i32 217, i32 185, i32 220, i32 247, i32 255,
	i32 152, i32 21, i32 188, i32 285, i32 50, i32 51, i32 311, i32 301,
	i32 94, i32 194, i32 297, i32 16, i32 123, i32 294, i32 160, i32 45,
	i32 272, i32 175, i32 116, i32 63, i32 166, i32 177, i32 14, i32 254,
	i32 111, i32 201, i32 60, i32 277, i32 121, i32 300, i32 2, i32 310,
	i32 226, i32 240, i32 276, i32 240, i32 6, i32 208, i32 290, i32 222,
	i32 17, i32 308, i32 287, i32 77, i32 212, i32 131, i32 274, i32 300,
	i32 83, i32 183, i32 12, i32 34, i32 119, i32 281, i32 235, i32 224,
	i32 85, i32 193, i32 18, i32 265, i32 178, i32 233, i32 72, i32 95,
	i32 165, i32 228, i32 82, i32 316, i32 202, i32 207, i32 277, i32 154,
	i32 36, i32 151, i32 312, i32 315, i32 144, i32 56, i32 113, i32 208,
	i32 262, i32 261, i32 37, i32 316, i32 177, i32 115, i32 200, i32 14,
	i32 194, i32 146, i32 43, i32 189, i32 198, i32 98, i32 280, i32 168,
	i32 16, i32 48, i32 107, i32 97, i32 244, i32 27, i32 128, i32 318,
	i32 29, i32 292, i32 255, i32 128, i32 44, i32 217, i32 223, i32 149,
	i32 8, i32 0, i32 191, i32 246, i32 293, i32 306, i32 305, i32 132,
	i32 304, i32 42, i32 281, i32 33, i32 319, i32 46, i32 143, i32 241,
	i32 187, i32 232, i32 218, i32 138, i32 62, i32 132, i32 284, i32 48,
	i32 160, i32 205, i32 232, i32 194, i32 230, i32 300, i32 261, i32 46,
	i32 164, i32 228, i32 289, i32 225, i32 296, i32 190, i32 18, i32 8,
	i32 175, i32 216, i32 124, i32 59, i32 141, i32 248, i32 299, i32 236,
	i32 270, i32 267, i32 150, i32 142, i32 279, i32 276, i32 126, i32 278,
	i32 160, i32 192, i32 162, i32 219, i32 197, i32 178, i32 302, i32 26,
	i32 246, i32 233, i32 82, i32 267, i32 127, i32 271, i32 101, i32 148,
	i32 269, i32 249, i32 54, i32 162, i32 167, i32 131, i32 37, i32 263,
	i32 299, i32 22, i32 112, i32 90, i32 220, i32 50, i32 60, i32 122,
	i32 83, i32 127, i32 163, i32 270, i32 166, i32 254, i32 256, i32 221,
	i32 193, i32 237, i32 4, i32 231, i32 295, i32 170, i32 2, i32 242,
	i32 116, i32 199, i32 19, i32 182, i32 89, i32 65, i32 30, i32 180,
	i32 288, i32 213, i32 59, i32 111, i32 233, i32 32, i32 128, i32 159,
	i32 306, i32 211, i32 140, i32 220, i32 302, i32 153, i32 17, i32 210,
	i32 196, i32 75, i32 74, i32 15, i32 169, i32 85, i32 277, i32 317,
	i32 124, i32 232, i32 243, i32 212, i32 309, i32 239, i32 34, i32 118,
	i32 139, i32 122, i32 106, i32 286, i32 263, i32 207, i32 293, i32 283,
	i32 54, i32 47, i32 28, i32 145, i32 182, i32 147, i32 35, i32 309,
	i32 173, i32 268, i32 75, i32 161, i32 174, i32 1, i32 257, i32 305,
	i32 298, i32 159, i32 12, i32 155, i32 151, i32 76, i32 103, i32 112,
	i32 204, i32 65, i32 66, i32 266, i32 45, i32 206, i32 109, i32 7,
	i32 176, i32 203, i32 55, i32 199, i32 64, i32 283, i32 216, i32 20,
	i32 109, i32 101, i32 62, i32 142, i32 197, i32 7, i32 298, i32 170,
	i32 50, i32 266, i32 115, i32 141, i32 175, i32 166, i32 80, i32 113,
	i32 243, i32 17, i32 73, i32 247, i32 89, i32 195, i32 87, i32 120,
	i32 260, i32 201, i32 135, i32 153, i32 106, i32 11, i32 90, i32 31,
	i32 311, i32 136, i32 303, i32 306, i32 258, i32 196, i32 176, i32 40,
	i32 319, i32 257, i32 139, i32 280, i32 282, i32 25, i32 315, i32 73,
	i32 228, i32 259, i32 192, i32 27, i32 67, i32 88, i32 95, i32 113,
	i32 31, i32 104, i32 231, i32 37, i32 72, i32 273, i32 108, i32 123,
	i32 203, i32 87, i32 181, i32 86, i32 297, i32 93, i32 180, i32 129,
	i32 317, i32 243, i32 260, i32 183, i32 254, i32 216, i32 259, i32 213,
	i32 270, i32 178, i32 163, i32 130, i32 182, i32 264, i32 251, i32 179,
	i32 10, i32 49, i32 313, i32 91, i32 313, i32 150, i32 62, i32 136,
	i32 150, i32 61, i32 181, i32 117, i32 137, i32 84, i32 229, i32 315,
	i32 159, i32 261, i32 143, i32 294, i32 225, i32 82, i32 70, i32 202,
	i32 136, i32 214, i32 195, i32 125, i32 54, i32 110, i32 130, i32 192,
	i32 88, i32 23, i32 74, i32 129, i32 31, i32 73, i32 238, i32 296,
	i32 158, i32 23, i32 4, i32 170, i32 304, i32 123, i32 295, i32 290,
	i32 114, i32 172, i32 32, i32 3, i32 164, i32 262, i32 30, i32 19,
	i32 237, i32 93, i32 36, i32 5, i32 268, i32 205, i32 278, i32 155,
	i32 258, i32 272, i32 212, i32 245, i32 264, i32 76, i32 63, i32 248,
	i32 317, i32 147, i32 209, i32 121, i32 134, i32 250, i32 273, i32 189,
	i32 100, i32 39, i32 197, i32 289, i32 68, i32 26, i32 75, i32 78,
	i32 236, i32 187, i32 24, i32 152, i32 38, i32 302, i32 205, i32 133,
	i32 103, i32 269, i32 57, i32 165, i32 91, i32 61, i32 132, i32 46,
	i32 133, i32 219, i32 145, i32 78, i32 214, i32 237, i32 154, i32 287,
	i32 83, i32 314, i32 191, i32 312, i32 61, i32 96, i32 252, i32 153,
	i32 293, i32 118, i32 184, i32 6, i32 15, i32 74, i32 283, i32 146,
	i32 52, i32 70, i32 23, i32 158, i32 126, i32 65, i32 245, i32 112,
	i32 247, i32 235, i32 55, i32 53, i32 221, i32 107, i32 135, i32 226,
	i32 236, i32 80, i32 230, i32 311, i32 234, i32 129, i32 64, i32 152
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 u0x0000000000000000, ; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/9.0.1xx @ e7876a4f92d894b40c191a24c2b74f06d4bf4573"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
