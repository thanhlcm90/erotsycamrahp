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
	public partial class LS_CUSTOMER
	{
		private int _id;
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
		
		private string _name;
		public virtual string Name 
		{ 
		    get
		    {
		        return this._name;
		    }
		    set
		    {
		        this._name = value;
		    }
		}
		
		private int _groupId;
		public virtual int GroupId 
		{ 
		    get
		    {
		        return this._groupId;
		    }
		    set
		    {
		        this._groupId = value;
		    }
		}
		
		private string _address;
		public virtual string Address 
		{ 
		    get
		    {
		        return this._address;
		    }
		    set
		    {
		        this._address = value;
		    }
		}
		
		private string _mobile;
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
		
		private string _email;
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
		
		private string _website;
		public virtual string Website 
		{ 
		    get
		    {
		        return this._website;
		    }
		    set
		    {
		        this._website = value;
		    }
		}
		
		private string _fax;
		public virtual string Fax 
		{ 
		    get
		    {
		        return this._fax;
		    }
		    set
		    {
		        this._fax = value;
		    }
		}
		
		private string _taxCode;
		public virtual string TaxCode 
		{ 
		    get
		    {
		        return this._taxCode;
		    }
		    set
		    {
		        this._taxCode = value;
		    }
		}
		
		private string _contactPerson;
		public virtual string ContactPerson 
		{ 
		    get
		    {
		        return this._contactPerson;
		    }
		    set
		    {
		        this._contactPerson = value;
		    }
		}
		
		private string _note;
		public virtual string Note 
		{ 
		    get
		    {
		        return this._note;
		    }
		    set
		    {
		        this._note = value;
		    }
		}
		
		private bool? _isCustomer;
		public virtual bool? IsCustomer 
		{ 
		    get
		    {
		        return this._isCustomer;
		    }
		    set
		    {
		        this._isCustomer = value;
		    }
		}
		
		private bool? _isManufaturer;
		public virtual bool? IsManufaturer 
		{ 
		    get
		    {
		        return this._isManufaturer;
		    }
		    set
		    {
		        this._isManufaturer = value;
		    }
		}
		
		private LS_CUSTOMER_GROUP _lS_CUSTOMER_GROUP;
		public virtual LS_CUSTOMER_GROUP LS_CUSTOMER_GROUP 
		{ 
		    get
		    {
		        return this._lS_CUSTOMER_GROUP;
		    }
		    set
		    {
		        this._lS_CUSTOMER_GROUP = value;
		    }
		}
		
		private IList<LS_DRUG> _lS_DRUGs = new List<LS_DRUG>();
		public virtual IList<LS_DRUG> LS_DRUGs 
		{ 
		    get
		    {
		        return this._lS_DRUGs;
		    }
		}
		
	}
}
