using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay
{
   /// <summary>
   /// Settings for the application
   /// - Language for the application
   /// - Progresspath of not finished routes
   /// - Password for login in application
   /// </summary>
    class Settings
   {

       ///  <value>
       ///  Default language is set to ENGLISH
       /// </value>
       ///  <summary>
       ///  The preferred language for the application in which the text is shown.
       ///  <type name="Language"/>
       ///  </summary>
       public static Language Language = Language.ENGLISH;

        /// <summary>
        /// 
        /// </summary>
       public static string Password = "";
        
        /// <summary>
        /// The path to saved progress, progress of a Route that has not been finished.
        /// </summary>
       public static string ProgressPath = "";
   }

    /// <summary>
    /// 
    /// </summary>
    enum Language
    {
        ENGLISH, DUTCH
    }
}
