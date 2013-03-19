/* -----------------------------------------------------------
ContentInjector.WOF
Copyright (C) 2013  Peter L. Blum

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace ContentInjector
{



/// <summary>
/// Use with ScriptFilesInjector to host a Web Optimization Framework
/// Bundle of scripts.
/// </summary>
/// <remarks>
/// <para>It's Add() method is a replacement for calling the Scripts.Render method.
/// By using Add() it eliminates duplicates and allows ordering.</para>
/// <para>The GetContent() method outputs the bundle information by 
/// calling Scripts.Render.</para>
/// </remarks>
   public class ScriptBundleInjectorItem : ScriptFileInjectorItem
   {
      public ScriptBundleInjectorItem(string bundleName)
         : base(bundleName)
      {
      }

      public override string GetContent(HttpContextBase httpContext)
      {
         return Scripts.Render(this.FileID).ToHtmlString().TrimEnd('\r', '\n');
      }

      protected override bool ConvertVirtualPaths()
      {
         return false;
      }

   }


}
