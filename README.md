<a href="http://insidethecpu.com/2015/04/10/protecting-asp-net-applications-against-csrf-attacks/">![Image of insidethecpu](https://dl.dropboxusercontent.com/u/26042707/Daishi%20Systems%20Icon%20with%20Text%20%28really%20tiny%20with%20photo%29.png)</a>
# ASP.NET ARMOR Web Framework
[![Join the chat at https://gitter.im/daishisystems/Daishi.Armor.WebFramework](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/daishisystems/Daishi.Armor.WebFramework?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Build status](https://ci.appveyor.com/api/projects/status/jne8objbtwxyaw7d?svg=true)](https://ci.appveyor.com/project/daishisystems/daishi-armor-webframework)
[![NuGet](https://img.shields.io/badge/nuget-v1.0.0.3-blue.svg)](https://www.nuget.org/packages/Daishi.Armor.WebFramework)

As seen on <a href="https://visualstudiomagazine.com/articles/2015/05/01/csrf-attacks.aspx">visualstudiomagazine.com</a>.

*The Encrypted Token Pattern is a defence mechanism against Cross Site Request Forgery (CSRF) attacks, and is an alternative to its sister-patterns; Synchroniser Token, and Double Submit Cookie. The ARMOR Web Framework provides a means to leverage this technique in repelling CSRF attacks against ASP.NET applications.*

Click <a href="http://insidethecpu.com/2015/04/10/protecting-asp-net-applications-against-csrf-attacks/">here for an in-depth tutorial</a> on protecting ASP.NET applications from CSRF attacks using this framework.
<a href="http://insidethecpu.com/2015/04/10/protecting-asp-net-applications-against-csrf-attacks/">![Image of ARMOR](https://dl.dropboxusercontent.com/u/26042707/daishi.armor.jpg)</a>
## Installation
```PM> Install-Package Daishi.Armor.WebFramework```
## Sample Code
### Generating Keys
ARMOR requires both encryption and hashing keys,  in Base64 format. You can generate both keys using the code below.

**Note**: Key-generation, rotation, and management are out-of-band topics in terms of leveraging ARMOR.
```cs
byte[] encryptionKey = new byte[32];
byte[] hashingKey = new byte[32];
 
using (var provider = new RNGCryptoServiceProvider()) {
    provider.GetBytes(encryptionKey);
    provider.GetBytes(hashingKey);
}
```
## Contact the Developer
Please reach out and contact me for questions, suggestions, or to just talk tech in general.


<a href="http://insidethecpu.com/feed/">![RSS](https://dl.dropboxusercontent.com/u/26042707/rss.png)</a><a href="https://twitter.com/daishisystems">![Twitter](https://dl.dropboxusercontent.com/u/26042707/twitter.png)</a><a href="https://www.linkedin.com/in/daishisystems">![LinkedIn](https://dl.dropboxusercontent.com/u/26042707/linkedin.png)</a><a href="https://plus.google.com/102806071104797194504/posts">![Google+](https://dl.dropboxusercontent.com/u/26042707/g.png)</a><a href="https://www.youtube.com/user/daishisystems">![YouTube](https://dl.dropboxusercontent.com/u/26042707/youtube.png)</a>