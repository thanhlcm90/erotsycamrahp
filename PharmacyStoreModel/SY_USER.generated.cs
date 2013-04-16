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
using PharmacyStoreModel;


namespace PharmacyStoreModel	
{
	[Table("SY_USER")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	public partial class SY_USER
	{
		private int _id;
		[Column("Id", OpenAccessType = OpenAccessType.Int32, IsBackendCalculated = true, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "int")]
		[Storage("_id")]
		public virtual int Id 
		{ 
		    get
		    {
		        return this._id;
		    }
		    set
		    {
		        this._id = value;
		    }
		}
		
		private string _userName;
		[Column("UserName", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_userName")]
		public virtual string UserName 
		{ 
		    get
		    {
		        return this._userName;
		    }
		    set
		    {
		        this._userName = value;
		    }
		}
		
		private string _fullname;
		[Column("Fullname", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_fullname")]
		public virtual string Fullname 
		{ 
		    get
		    {
		        return this._fullname;
		    }
		    set
		    {
		        this._fullname = value;
		    }
		}
		
		private string _email;
		[Column("Email", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_email")]
		public virtual string Email 
		{ 
		    get
		    {
		        return this._email;
		    }
		    set
		    {
		        this._email = value;
		    }
		}
		
		private string _gender;
		[Column("Gender", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_gender")]
		public virtual string Gender 
		{ 
		    get
		    {
		        return this._gender;
		    }
		    set
		    {
		        this._gender = value;
		    }
		}
		
		private DateTime _birthdate;
		[Column("Birthdate", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_birthdate")]
		public virtual DateTime Birthdate 
		{ 
		    get
		    {
		        return this._birthdate;
		    }
		    set
		    {
		        this._birthdate = value;
		    }
		}
		
		private string _mobile;
		[Column("Mobile", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_mobile")]
		public virtual string Mobile 
		{ 
		    get
		    {
		        return this._mobile;
		    }
		    set
		    {
		        this._mobile = value;
		    }
		}
		
		private string _userRefer;
		[Column("UserRefer", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_userRefer")]
		public virtual string UserRefer 
		{ 
		    get
		    {
		        return this._userRefer;
		    }
		    set
		    {
		        this._userRefer = value;
		    }
		}
		
		private string _identification;
		[Column("Identification", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "nvarchar(max)")]
		[Storage("_identification")]
		public virtual string Identification 
		{ 
		    get
		    {
		        return this._identification;
		    }
		    set
		    {
		        this._identification = value;
		    }
		}
		
		private IList<SY_STORE> _sY_STOREs = new List<SY_STORE>();
		[Collection(InverseProperty = "SY_USER")]
		[Storage("_sY_STOREs")]
		public virtual IList<SY_STORE> SY_STOREs 
		{ 
		    get
		    {
		        return this._sY_STOREs;
		    }
		}
		
		private IList<Webpages_Role> _webpages_Roles = new List<Webpages_Role>();
		[Collection(InverseProperty = "SY_USERs")]
		[Storage("_webpages_Roles")]
		public virtual IList<Webpages_Role> Webpages_Roles 
		{ 
		    get
		    {
		        return this._webpages_Roles;
		    }
		}
		
	}
}
