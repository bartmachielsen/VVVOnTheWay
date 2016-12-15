﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay
{
   /// <summary>
   /// Settings for the application that are generally used.
   /// </summary>
    class Settings
   {
       ///  <value>
       ///  Default language is set to ENGLISH
       /// </value>
       ///  <summary>
       ///  The preferred language for the application in which the text is shown.
       ///  <type name="Language"/>
       ///  <seealso cref="Language"/>
       ///  </summary>
       public static Language Language = Language.ENGLISH;

        public static void setLanguageDutch()
        {
            Language = Language.DUTCH;
        }
        public static void setLanguageEnglish()
        {
            Language = Language.ENGLISH;
        }

        /// <summary>
        /// The correct password that is needed to login, 
        /// must completely match to correctly login.
        /// </summary>
        public static string Password = "";
        
        /// <summary>
        /// The path to saved progress, progress of a Route that has not been finished.
        /// </summary>
       public static string ProgressPath = "";

        
       

       
   }

    /// <summary>
    /// Language enum that represents the languages that are available to translate the textcontent.
    /// </summary>
    enum Language
    {
        /// <summary>
        /// Translation in the English Language
        /// Represents the value 0
        /// </summary>
        ENGLISH,

        /// <summary>
        /// Translation in the Dutch Language
        /// Represents the value 1
        /// </summary>
        DUTCH
    }
}
