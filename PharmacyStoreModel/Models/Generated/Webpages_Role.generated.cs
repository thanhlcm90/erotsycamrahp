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
using PharmacyStore.Models;


namespace PharmacyStore.Models	
{
	public partial class Webpages_Role
	{
		private int _roleId;
		public virtual int RoleId 
		{ 
		    get
		    {
		        return this._roleId;
		    }
		    set
		    {
		        this._roleId = value;
		    }
		}
		
		private string _roleName;
		public virtual string RoleName 
		{ 
		    get
		    {
		        return this._roleName;
		    }
		    set
		    {
		        this._roleName = value;
		    }
		}
		
		private IList<SY_USER> _sY_USERs = new List<SY_USER>();
		public virtual IList<SY_USER> SY_USERs 
		{ 
		    get
		    {
		        return this._sY_USERs;
		    }
		}
		
	}
}
