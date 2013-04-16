﻿#pragma warning disable 1591
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
	public partial class PharmacyStoreModel : OpenAccessContext, IPharmacyStoreModelUnitOfWork
	{
		private static string connectionStringName = @"PharmacyStoreConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
		
			
		private static MetadataSource metadataSource = AttributesMetadataSource.FromContext(typeof(PharmacyStoreModel));
	
		public PharmacyStoreModel()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public PharmacyStoreModel(string connection)
			:base(connection, backend, metadataSource)
		{ }
	
		public PharmacyStoreModel(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public PharmacyStoreModel(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public PharmacyStoreModel(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Webpages_Role> Webpages_Roles 
		{
	    	get
	    	{
	        	return this.GetAll<Webpages_Role>();
	    	}
		}
		
		public IQueryable<Webpages_OAuthMembership> Webpages_OAuthMemberships 
		{
	    	get
	    	{
	        	return this.GetAll<Webpages_OAuthMembership>();
	    	}
		}
		
		public IQueryable<Webpages_Membership> Webpages_Memberships 
		{
	    	get
	    	{
	        	return this.GetAll<Webpages_Membership>();
	    	}
		}
		
		public IQueryable<SY_USER> SY_USERs 
		{
	    	get
	    	{
	        	return this.GetAll<SY_USER>();
	    	}
		}
		
		public IQueryable<SY_STORE> SY_STOREs 
		{
	    	get
	    	{
	        	return this.GetAll<SY_STORE>();
	    	}
		}
		
		public IQueryable<LS_DOCTOR> LS_DOCTORs 
		{
	    	get
	    	{
	        	return this.GetAll<LS_DOCTOR>();
	    	}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
			return backend;
		}
	}

	public interface IPharmacyStoreModelUnitOfWork : IUnitOfWork
	{
		IQueryable<Webpages_Role> Webpages_Roles 
		{ 
			get;
		}

		IQueryable<Webpages_OAuthMembership> Webpages_OAuthMemberships 
		{ 
			get;
		}

		IQueryable<Webpages_Membership> Webpages_Memberships 
		{ 
			get;
		}

		IQueryable<SY_USER> SY_USERs 
		{ 
			get;
		}

		IQueryable<SY_STORE> SY_STOREs 
		{ 
			get;
		}

		IQueryable<LS_DOCTOR> LS_DOCTORs 
		{ 
			get;
		}

	}
}
#pragma warning restore 1591

