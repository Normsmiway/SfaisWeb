using SfaisWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfaisWeb.Code
{
    public static class Converter
    {
        public static string[] JsToCSharp(string JsObject)
        {
            List<string> step2Result = new List<string>();
            //Check the string , plits by }
            //from each object, remove starting ,
            var step1Result = JsObject.Split(new char[] { '}' });

            foreach (string data  in step1Result)
            {
               var d= data.TrimStart(new char[] { '{', ',' }).Replace(':','=').Replace('\'','"').Trim(new char[] {'{' });
                step2Result.Add(d);
            }
            var m = step2Result.ToString();
            return step1Result;

        }
    }
}