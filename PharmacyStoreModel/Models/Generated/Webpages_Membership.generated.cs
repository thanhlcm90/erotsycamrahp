#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;


namespace PharmacyStore.Models	
{
	public partial class Webpages_Membership
	{
		private int _userId;
		public virtual int UserId 
		{ 
		    get
		    {
		        return this._userId;
		    }
		    set
		    {
		        this._userId = value;
		    }
		}
		
		private DateTime? _createDate;
		public virtual DateTime? CreateDate 
		{ 
		    get
		    {
		        return this._createDate;
		    }
		    set
		    {
		        this._createDate = value;
		    }
		}
		
		private string _confirmationToken;
		public virtual string ConfirmationToken 
		{ 
		    get
		    {
		        return this._confirmationToken;
		    }
		    set
		    {
		        this._confirmationToken = value;
		    }
		}
		
		private bool? _isConfirmed;
		public virtual bool? IsConfirmed 
		{ 
		    get
		    {
		        return this._isConfirmed;
		    }
		    set
		    {
		        this._isConfirmed = value;
		    }
		}
		
		private DateTime? _lastPasswordFailureDate;
		public virtual DateTime? LastPasswordFailureDate 
		{ 
		    get
		    {
		        return this._lastPasswordFailureDate;
		    }
		    set
		    {
		        this._lastPasswordFailureDate = value;
		    }
		}
		
		private int _passwordFailuresSinceLastSuccess;
		public virtual int PasswordFailuresSinceLastSuccess 
		{ 
		    get
		    {
		        return this._passwordFailuresSinceLastSuccess;
		    }
		    set
		    {
		        this._passwordFailuresSinceLastSuccess = value;
		    }
		}
		
		private string _password;
		public virtual string Password 
		{ 
		    get
		    {
		        return this._password;
		    }
		    set
		    {
		        this._password = value;
		    }
		}
		
		private DateTime? _passwordChangedDate;
		public virtual DateTime? PasswordChangedDate 
		{ 
		    get
		    {
		        return this._passwordChangedDate;
		    }
		    set
		    {
		        this._passwordChangedDate = value;
		    }
		}
		
		private string _passwordSalt;
		public virtual string PasswordSalt 
		{ 
		    get
		    {
		        return this._passwordSalt;
		    }
		    set
		    {
		        this._passwordSalt = value;
		    }
		}
		
		private string _passwordVerificationToken;
		public virtual string PasswordVerificationToken 
		{ 
		    get
		    {
		        return this._passwordVerificationToken;
		    }
		    set
		    {
		        this._passwordVerificationToken = value;
		    }
		}
		
		private DateTime? _passwordVerificationTokenExpirationDate;
		public virtual DateTime? PasswordVerificationTokenExpirationDate 
		{ 
		    get
		    {
		        return this._passwordVerificationTokenExpirationDate;
		    }
		    set
		    {
		        this._passwordVerificationTokenExpirationDate = value;
		    }
		}
		
	}
}
