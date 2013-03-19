#Content Injector support for Web Optimization Framework
<p>Extends <b><a href="https://github.com/plblum/ContentInjector" target="_blank">Content Injector for ASP.NET MVC</a></b> with support for the bundling features
of Microsoft's <a href="http://aspnetoptimization.codeplex.com/" target="_blank">Web Optimization Framework</a>.</p>
<p>Content Injector improves the Web Optimization Framework in several ways:</p>
<ul type="disc">
<li>Allows script and style sheet files to be injected anywhere in the page. You just add
@Injector.InjectionPoint("ScriptFiles") and @Injector.InjectionPoint("StyleFiles") where you want 
all of these files to appear. (Usually they appear in the &lt;head&gt; tag, although its also common
to place script files at the end of the HTML.)</li>
<li>A View or HTML Helper can inject its own script and style sheet files and know they will appear 
with all other script or style sheet files.</li>
<li>Duplicate requests for a file will be omitted. This is especially useful for HTML Helpers
which will register the files they need with each usage.</li>
<li>Since the file list is not processed until all requests have been registered,
ContentInjector can order them to ensure dependencies appear earlier.</li>
</ul>
<h2>Requires</h2>
<ul type="disc">
<li>Content Injector for ASP.NET MVC, available through NuGet or <a href="https://github.com/plblum/ContentInjector">here</a>.</li>
<li>Web Optimization Framework 1.0, available through NuGet or <a href="http://aspnetoptimization.codeplex.com/">here</a>.</li>
</ul>
<h2>Overview</h2>
<p>This library extends the Injection Points for "ScriptFiles" and "StyleFiles" within ContentInjector. Normally when working
with Web Optimization Framework, you add @Scripts.Render("bundle name") and @Styles.Render("bundle name")
into your View to have those bundles converted into HTML.</p>
<p>When using Content Injector, add Injector.ScriptBundle("bundle name") and Injector.StyleBundle("bundle name")
into your View like this:</p>
<pre style='background:#FFEFE6;font-size:10pt;font-family:"Lucida Console"'>@{<br />&nbsp;&nbsp;&nbsp;Injector.ScriptBundle("~/Scripts/jquery");<br />&nbsp;&nbsp;&nbsp;Injector.StyleBundle("~/Content/css");<br />}</pre>
<p>You can also add a string array containing multiple bundle names like this:</p>
<pre style='background:#FFEFE6;font-size:10pt;font-family:"Lucida Console"'>@{<br />&nbsp;&nbsp;&nbsp;Injector.ScriptBundle(new string[] {"~/Scripts/jquery", "~/Scripts/Modernizer"});<br />}</pre>

<p>A typical master page looks like this:</p>

<pre style='background:#FFEFE6'><span
style='font-size:10pt;font-family:"Lucida Console";color:black;background:
yellow'>@{</span><span style='font-size:10pt;font-family:"Lucida Console";
color:black'></span><br /><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>&nbsp;&nbsp;&nbsp;&nbsp;</span><span
class=GramE><span style='font-size:10pt;font-family:"Lucida Console";
color:black'>Injector</span></span><span style='font-size:10pt;
font-family:"Lucida Console";color:black'>.ScriptBundle(</span><span
style='font-size:10pt;font-family:"Lucida Console";color:#A31515'>&quot;~/Scripts/jquery&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>);</span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:black'>&nbsp;&nbsp;&nbsp;&nbsp;</span><span class=GramE><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>Injector</span></span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>.ScriptBundle(</span><span
style='font-size:10pt;font-family:"Lucida Console";color:#A31515'>&quot;~/Scripts/modernizr&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>);</span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:black'>&nbsp;&nbsp;&nbsp;&nbsp;</span><span class=GramE><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>Injector</span></span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>.StyleBundle(</span><span
style='font-size:10pt;font-family:"Lucida Console";color:#A31515'>&quot;~/Content/css&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>;</span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:black;background:yellow'>}</span><span style='font-size:10pt;font-family:
"Lucida Console";color:black'></span><br /><span class=GramE><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;!</span><span style='font-size:10pt;font-family:"Lucida Console";
color:maroon'>DOCTYPE</span></span><span style='font-size:10pt;font-family:
"Lucida Console";color:black'>&nbsp;</span><span style='font-size:10pt;
font-family:"Lucida Console";color:red'>html</span><span style='font-size:10pt;
font-family:"Lucida Console";color:blue'>&gt;</span><span style='font-size:
10pt;font-family:"Lucida Console";color:black'></span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;</span><span class=GramE><span style='font-size:10pt;
font-family:"Lucida Console";color:maroon'>html</span></span><span
style='font-size:10pt;font-family:"Lucida Console";color:blue'>&gt;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'></span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;</span><span class=GramE><span style='font-size:10pt;
font-family:"Lucida Console";color:maroon'>head</span></span><span
style='font-size:10pt;font-family:"Lucida Console";color:blue'>&gt;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'></span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:black'>&nbsp;&nbsp;&nbsp;&nbsp;</span><span style='font-size:10pt;
font-family:"Lucida Console";color:blue'>&lt;</span><span style='font-size:
10pt;font-family:"Lucida Console";color:maroon'>title</span><span
style='font-size:10pt;font-family:"Lucida Console";color:blue'>&gt;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black;background:
yellow'>@</span><span style='font-size:10pt;font-family:"Lucida Console";
color:black'>ViewBag.Title</span><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;/</span><span style='font-size:10pt;font-family:"Lucida Console";
color:maroon'>title</span><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&gt;</span><span style='font-size:10pt;font-family:"Lucida Console";
color:black'></span><br /><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>&nbsp;&nbsp;&nbsp;&nbsp;<span 
      style="background-color: #FFFF00;">@</span>Injector.InjectionPoint(</span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;MetaTag&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>)<br />&nbsp;&nbsp;&nbsp;&nbsp;<span 
      style="background-color: #FFFF00;">@</span>Injector.InjectionPoint(</span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;StyleFiles&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>)<br />&nbsp;&nbsp;&nbsp;&nbsp;<span 
      style="background-color: #FFFF00;">@</span>Injector.InjectionPoint(</span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;ScriptFiles&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>)</span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;/</span><span style='font-size:10pt;font-family:"Lucida Console";
color:maroon'>head</span><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&gt;</span><span style='font-size:10pt;font-family:"Lucida Console";
color:black'></span><br /><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>    </span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;</span><span class=GramE><span style='font-size:10pt;
font-family:"Lucida Console";color:maroon'>body</span></span><span
style='font-size:10pt;font-family:"Lucida Console";color:blue'>&gt;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'></span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:black'><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>&nbsp;&nbsp;&nbsp;&nbsp;<span 
      style="background-color: #FFFF00;">@</span>Injector.InjectionPoint(</span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;ScriptBlocks&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";'>, </span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;Upper&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>)<br /></span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=GramE><span style='background:
yellow'>@</span>RenderBody()</span></span><br /><span style='font-size:10pt;font-family:"Lucida Console";
color:black'><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>&nbsp;&nbsp;&nbsp;&nbsp;<span 
      style="background-color: #FFFF00;">@</span>Injector.InjectionPoint(</span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;ScriptBlocks&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";'>, </span><span
style='font-size:10pt;font-family:"Lucida Console";color: #A31515;'>&quot;Lower&quot;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'>)<br /></span></span><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&lt;/</span><span style='font-size:10pt;font-family:"Lucida Console";
color:maroon'>body</span><span style='font-size:10pt;font-family:"Lucida Console";
color:blue'>&gt;</span><span style='font-size:10pt;font-family:"Lucida Console";
color:black'></span><br /><span
style='font-size:10pt;font-family:"Lucida Console";color:blue'>&lt;/</span><span
style='font-size:10pt;font-family:"Lucida Console";color:maroon'>html</span><span
style='font-size:10pt;font-family:"Lucida Console";color:blue'>&gt;</span><span
style='font-size:10pt;font-family:"Lucida Console";color:black'></span></pre>
<p>Only the ScriptFiles and StyleFiles Injection Points are impacted by this extension. The remaining Injection Points
are managed by the default features of Content Injector for ASP.NET MVC.</p>
<h2>Getting Started</h2>
<ul type='disc'>
<li>Install this library using NuGet or add its assembly from <a href="https://github.com/plblum/ContentInjector.WOF/Assemblies/ContentInjector.WOF.dll?Raw=true" target="_blank"></a>here.</li>
<li>If you did not install using NuGet, also add Content Injector and Web Optimization Framework.</li>
<li>Configure the Bundles features of Web Optimization Framework. Please refer to the 
<a href="http://aspnetoptimization.codeplex.com/documentation" target="_blank">documentation for
that product</a>. This work is done in code that is run during application start and is typically 
found in a file called BundleConfig.cs.</li>
<li>When you a View or Html Helper needs a script bundle, it should use <br />
<pre style='background:#FFEFE6;font-size:10pt;font-family:"Lucida Console"'>@ { Injector.ScriptBundle("bundle name"); }</pre></li>
<li>When you a View or Html Helper needs a style bundle, it should use <br />
<pre style='background:#FFEFE6;font-size:10pt;font-family:"Lucida Console"'>@ { Injector.StyleBundle("bundle name"); }</pre></li>
</ul>