﻿using System;
using System.Text.RegularExpressions;


namespace Routing.Pages.Helpers
{
    public class ValidationHelper
    {
        public bool LikeGUID(string guid)
        {
            string regular = @"(?i)\b[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}\b";
            Regex rgx = new Regex(regular);
            return rgx.IsMatch(guid);
        }

        public bool LikeName(string name)
        {
            Regex rgx = new Regex(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$");            
            return rgx.IsMatch(name);
        }

        public bool LikePhoneNumber(string phoneNumber)
        {
            Regex rgx = new Regex(@"(?x) \d{3} - \d{3}-\d{2}-\d{2}");
            bool answ = rgx.IsMatch(phoneNumber);
            return answ;
        }    

        public bool LikeAddress(string address)
        {
            //Regex rgx = new Regex(@"^[a-zA-Zа-яА-Я,-;:]+$");           
            //return rgx.IsMatch(address);
            return true;
        }
    }
}