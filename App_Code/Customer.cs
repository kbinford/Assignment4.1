﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string LastName { set; get; }
    public string FirstName { set; get; }
    public string email { set; get; }
    public string password { set; get; }
    public int passcode { set; get; }
    public Byte[] PasswordHash { set; get; }
    public string street { set; get; }
    public string apartment { set; get; }
    public string state { set; get; }
    public string city { set; get; }
    public string zip { set; get; }
    public string phone { set; get; }
}