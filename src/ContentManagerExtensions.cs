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
using System.Web.Optimization;
using System.Collections.ObjectModel;

namespace ContentInjector
{

/// <summary>
/// Extension methods designed for the ContentManager class that simplify accessing 
/// the Access&lt;T&gt;Add methods.
/// </summary>
   public static class ContentManagerExtensions
   {

      public static void ScriptBundle(this ContentManager contentInjector, string bundleName, int order = 0, string group = "")
      {
         order = AdjustOrder(bundleName, order);
         contentInjector.Access<IScriptFilesInjector>(group).Add(new ScriptBundleInjectorItem(bundleName), order);
      }

      public static void ScriptBundle(this ContentManager contentInjector, string[] bundleNames, int order = 0, string group = "")
      {
         foreach (string bundleName in bundleNames)
         {
            int newOrder = AdjustOrder(bundleName, order);
            contentInjector.Access<IScriptFilesInjector>(group).Add(new ScriptBundleInjectorItem(bundleName), newOrder);
         }
      }

      public static void ScriptBundle(this ContentManager contentInjector, ScriptBundleInjectorItem item, int order = 0, string group = "")
      {
         order = AdjustOrder(item.FileID, order);
         contentInjector.Access<IScriptFilesInjector>(group).Add(item, order);
      }


      public static void StyleBundle(this ContentManager contentInjector, string bundleName, int order = 0, string group = "")
      {
         order = AdjustOrder(bundleName, order);
         contentInjector.Access<IStyleFilesInjector>(group).Add(new StyleBundleInjectorItem(bundleName), order);
      }

      public static void StyleBundle(this ContentManager contentInjector, string[] bundleNames, int order = 0, string group = "")
      {
         foreach (string bundleName in bundleNames)
         {
            int newOrder = AdjustOrder(bundleName, order);
            contentInjector.Access<IStyleFilesInjector>(group).Add(new StyleBundleInjectorItem(bundleName), newOrder);
         }
      }

      public static void StyleBundle(this ContentManager contentInjector, StyleBundleInjectorItem item, int order = 0, string group = "")
      {
         order = AdjustOrder(item.FileID, order);
         contentInjector.Access<IStyleFilesInjector>(group).Add(item, order);
      }

/// <summary>
/// Changes the order to the position in the Bundles collection, which is sorted to reflect ordering.
/// Only changes the order when its 0.
/// </summary>
/// <param name="bundleName"></param>
/// <param name="order"></param>
/// <returns></returns>
      static int AdjustOrder(string bundleName, int order)
      {
         if (order == 0)
         {
            ReadOnlyCollection<Bundle> bundles = BundleTable.Bundles.GetRegisteredBundles();

            for (int i = 0; i < bundles.Count; i++)
            {
               if (String.Compare(bundleName, bundles[i].Path, StringComparison.InvariantCultureIgnoreCase) == 0)
               {
                  order = i;
                  break;
               }
            }
         }
         return order;
      }
   }
}
