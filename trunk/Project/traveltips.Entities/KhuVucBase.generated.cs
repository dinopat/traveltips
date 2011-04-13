﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file KhuVuc.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace traveltips.Entities
{
	///<summary>
	/// An object representation of the 'tbl_KhuVuc' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class KhuVucBase : EntityBase, traveltips.Entities.IKhuVuc, IEntityId<KhuVucKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private KhuVucEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private KhuVucEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private KhuVucEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<KhuVuc> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event KhuVucEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event KhuVucEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="KhuVucBase"/> instance.
		///</summary>
		public KhuVucBase()
		{
			this.entityData = new KhuVucEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="KhuVucBase"/> instance.
		///</summary>
		///<param name="idKhuVuc"></param>
		///<param name="tenKv"></param>
		///<param name="maKv"></param>
		///<param name="moTa"></param>
		///<param name="flag"></param>
		public KhuVucBase(System.Int64 idKhuVuc, System.String tenKv, System.Byte[] maKv, 
			System.String moTa, System.Byte? flag)
		{
			this.entityData = new KhuVucEntityData();
			this.backupData = null;

			this.IdKhuVuc = idKhuVuc;
			this.TenKv = tenKv;
			this.MaKv = maKv;
			this.MoTa = moTa;
			this.Flag = flag;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="KhuVuc"/> instance.
		///</summary>
		///<param name="idKhuVuc"></param>
		///<param name="tenKv"></param>
		///<param name="maKv"></param>
		///<param name="moTa"></param>
		///<param name="flag"></param>
		public static KhuVuc CreateKhuVuc(System.Int64 idKhuVuc, System.String tenKv, System.Byte[] maKv, 
			System.String moTa, System.Byte? flag)
		{
			KhuVuc newKhuVuc = new KhuVuc();
			newKhuVuc.IdKhuVuc = idKhuVuc;
			newKhuVuc.TenKv = tenKv;
			newKhuVuc.MaKv = maKv;
			newKhuVuc.MoTa = moTa;
			newKhuVuc.Flag = flag;
			return newKhuVuc;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the IdKhuVuc property. 
		///		
		/// </summary>
		/// <value>This type is bigint.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false)]
		public virtual System.Int64 IdKhuVuc
		{
			get
			{
				return this.entityData.IdKhuVuc; 
			}
			
			set
			{
				if (this.entityData.IdKhuVuc == value)
					return;
					
				OnColumnChanging(KhuVucColumn.IdKhuVuc, this.entityData.IdKhuVuc);
				this.entityData.IdKhuVuc = value;
				this.EntityId.IdKhuVuc = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(KhuVucColumn.IdKhuVuc, this.entityData.IdKhuVuc);
				OnPropertyChanged("IdKhuVuc");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the id_KhuVuc property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the id_KhuVuc property.</remarks>
		/// <value>This type is bigint</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Int64 OriginalIdKhuVuc
		{
			get { return this.entityData.OriginalIdKhuVuc; }
			set { this.entityData.OriginalIdKhuVuc = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the TenKv property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 255)]
		public virtual System.String TenKv
		{
			get
			{
				return this.entityData.TenKv; 
			}
			
			set
			{
				if (this.entityData.TenKv == value)
					return;
					
				OnColumnChanging(KhuVucColumn.TenKv, this.entityData.TenKv);
				this.entityData.TenKv = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(KhuVucColumn.TenKv, this.entityData.TenKv);
				OnPropertyChanged("TenKv");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MaKv property. 
		///		
		/// </summary>
		/// <value>This type is varbinary.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true)]
		public virtual System.Byte[] MaKv
		{
			get
			{
				return this.entityData.MaKv; 
			}
			
			set
			{
				if (this.entityData.MaKv == value)
					return;
					
				OnColumnChanging(KhuVucColumn.MaKv, this.entityData.MaKv);
				this.entityData.MaKv = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(KhuVucColumn.MaKv, this.entityData.MaKv);
				OnPropertyChanged("MaKv");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MoTa property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 1000)]
		public virtual System.String MoTa
		{
			get
			{
				return this.entityData.MoTa; 
			}
			
			set
			{
				if (this.entityData.MoTa == value)
					return;
					
				OnColumnChanging(KhuVucColumn.MoTa, this.entityData.MoTa);
				this.entityData.MoTa = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(KhuVucColumn.MoTa, this.entityData.MoTa);
				OnPropertyChanged("MoTa");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Flag property. 
		///		
		/// </summary>
		/// <value>This type is tinyint.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (byte)0. It is up to the developer
		/// to check the value of IsFlagNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true)]
		public override System.Byte? Flag
		{
			get
			{
				return this.entityData.Flag; 
			}
			
			set
			{
				if (this.entityData.Flag == value)
					return;
					
				OnColumnChanging(KhuVucColumn.Flag, this.entityData.Flag);
				this.entityData.Flag = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(KhuVucColumn.Flag, this.entityData.Flag);
				OnPropertyChanged("Flag");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
		#endregion Children Collections
		
		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("TenKv", "Ten Kv", 255));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("MoTa", "Mo Ta", 1000));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "tbl_KhuVuc"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"id_KhuVuc", "TenKV", "MaKV", "MoTa", "Flag"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as KhuVucEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (KhuVuc) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<KhuVuc>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as KhuVuc);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed KhuVuc Entity 
		///</summary>
		public virtual KhuVuc Copy()
		{
			//shallow copy entity
			KhuVuc copy = new KhuVuc();
			copy.SuppressEntityEvents = true;
			copy.IdKhuVuc = this.IdKhuVuc;
			copy.OriginalIdKhuVuc = this.OriginalIdKhuVuc;
			copy.TenKv = this.TenKv;
			copy.MaKv = this.MaKv;
			copy.MoTa = this.MoTa;
			copy.Flag = this.Flag;
			
		
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed KhuVuc Entity which is a deep copy of the current entity.
		///</summary>
		public virtual KhuVuc DeepCopy()
		{
			return EntityHelper.Clone<KhuVuc>(this as KhuVuc);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as KhuVucEntityData;
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as KhuVucEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(KhuVucColumn column)
		{
			switch(column)
			{
					case KhuVucColumn.IdKhuVuc:
					return entityData.IdKhuVuc != _originalData.IdKhuVuc;
					case KhuVucColumn.TenKv:
					return entityData.TenKv != _originalData.TenKv;
					case KhuVucColumn.MaKv:
					return entityData.MaKv != _originalData.MaKv;
					case KhuVucColumn.MoTa:
					return entityData.MoTa != _originalData.MoTa;
					case KhuVucColumn.Flag:
					return entityData.Flag != _originalData.Flag;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has data changed]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.IdKhuVuc != _originalData.IdKhuVuc;
			result = result || entityData.TenKv != _originalData.TenKv;
			result = result || entityData.MaKv != _originalData.MaKv;
			result = result || entityData.MoTa != _originalData.MoTa;
			result = result || entityData.Flag != _originalData.Flag;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="KhuVucBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is KhuVucBase)
				return Equals(this, (KhuVucBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="KhuVucBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.IdKhuVuc.GetHashCode() ^ 
					((this.TenKv == null) ? string.Empty : this.TenKv.ToString()).GetHashCode() ^ 
					((this.MaKv == null) ? string.Empty : this.MaKv.ToString()).GetHashCode() ^ 
					((this.MoTa == null) ? string.Empty : this.MoTa.ToString()).GetHashCode() ^ 
					((this.Flag == null) ? string.Empty : this.Flag.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="KhuVucBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(KhuVucBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="KhuVucBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="KhuVucBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="KhuVucBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(KhuVucBase Object1, KhuVucBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.IdKhuVuc != Object2.IdKhuVuc)
				equal = false;
			if ( Object1.TenKv != null && Object2.TenKv != null )
			{
				if (Object1.TenKv != Object2.TenKv)
					equal = false;
			}
			else if (Object1.TenKv == null ^ Object2.TenKv == null )
			{
				equal = false;
			}
			if ( Object1.MaKv != null && Object2.MaKv != null )
			{
				if (Object1.MaKv != Object2.MaKv)
					equal = false;
			}
			else if (Object1.MaKv == null ^ Object2.MaKv == null )
			{
				equal = false;
			}
			if ( Object1.MoTa != null && Object2.MoTa != null )
			{
				if (Object1.MoTa != Object2.MoTa)
					equal = false;
			}
			else if (Object1.MoTa == null ^ Object2.MoTa == null )
			{
				equal = false;
			}
			if ( Object1.Flag != null && Object2.Flag != null )
			{
				if (Object1.Flag != Object2.Flag)
					equal = false;
			}
			else if (Object1.Flag == null ^ Object2.Flag == null )
			{
				equal = false;
			}
					
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((KhuVucBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static KhuVucComparer GetComparer()
        {
            return new KhuVucComparer();
        }
        */

        // Comparer delegates back to KhuVuc
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(KhuVuc rhs, KhuVucColumn which)
        {
            switch (which)
            {
            	
            	
            	case KhuVucColumn.IdKhuVuc:
            		return this.IdKhuVuc.CompareTo(rhs.IdKhuVuc);
            		
            		                 
            	
            	
            	case KhuVucColumn.TenKv:
            		return this.TenKv.CompareTo(rhs.TenKv);
            		
            		                 
            	
            		                 
            	
            	
            	case KhuVucColumn.MoTa:
            		return this.MoTa.CompareTo(rhs.MoTa);
            		
            		                 
            	
            	
            	case KhuVucColumn.Flag:
            		return this.Flag.Value.CompareTo(rhs.Flag.Value);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<KhuVucKey> Members
		
		// member variable for the EntityId property
		private KhuVucKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual KhuVucKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new KhuVucKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("KhuVuc")
					.Append("|").Append( this.IdKhuVuc.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{6}{5}- IdKhuVuc: {0}{5}- TenKv: {1}{5}- MaKv: {2}{5}- MoTa: {3}{5}- Flag: {4}{5}", 
				this.IdKhuVuc,
				(this.TenKv == null) ? string.Empty : this.TenKv.ToString(),
				(this.MaKv == null) ? string.Empty : this.MaKv.ToString(),
				(this.MoTa == null) ? string.Empty : this.MoTa.ToString(),
				(this.Flag == null) ? string.Empty : this.Flag.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'tbl_KhuVuc' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class KhuVucEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// id_KhuVuc : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tbl_KhuVuc"</remarks>
			public System.Int64 IdKhuVuc;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Int64 OriginalIdKhuVuc;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// TenKV : 
		/// </summary>
		public System.String		  TenKv = null;
		
		/// <summary>
		/// MaKV : 
		/// </summary>
		public System.Byte[]		  MaKv = null;
		
		/// <summary>
		/// MoTa : 
		/// </summary>
		public System.String		  MoTa = null;
		
		/// <summary>
		/// Flag : 
		/// </summary>
		public System.Byte?		  Flag = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			KhuVucEntityData _tmp = new KhuVucEntityData();
						
			_tmp.IdKhuVuc = this.IdKhuVuc;
			_tmp.OriginalIdKhuVuc = this.OriginalIdKhuVuc;
			
			_tmp.TenKv = this.TenKv;
			_tmp.MaKv = this.MaKv;
			_tmp.MoTa = this.MoTa;
			_tmp.Flag = this.Flag;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct



		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="KhuVucColumn"/> which has raised the event.</param>
		public void OnColumnChanging(KhuVucColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="KhuVucColumn"/> which has raised the event.</param>
		public void OnColumnChanged(KhuVucColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="KhuVucColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(KhuVucColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				KhuVucEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new KhuVucEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="KhuVucColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(KhuVucColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				KhuVucEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new KhuVucEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region KhuVucEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="KhuVuc"/> object.
	/// </remarks>
	public class KhuVucEventArgs : System.EventArgs
	{
		private KhuVucColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the KhuVucEventArgs class.
		///</summary>
		public KhuVucEventArgs(KhuVucColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the KhuVucEventArgs class.
		///</summary>
		public KhuVucEventArgs(KhuVucColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The KhuVucColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="KhuVucColumn" />
		public KhuVucColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all KhuVuc related events.
	///</summary>
	public delegate void KhuVucEventHandler(object sender, KhuVucEventArgs e);
	
	#region KhuVucComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class KhuVucComparer : System.Collections.Generic.IComparer<KhuVuc>
	{
		KhuVucColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:KhuVucComparer"/> class.
        /// </summary>
		public KhuVucComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:KhuVucComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public KhuVucComparer(KhuVucColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="KhuVuc"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="KhuVuc"/> to compare.</param>
        /// <param name="b">The second <c>KhuVuc</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(KhuVuc a, KhuVuc b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(KhuVuc entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(KhuVuc a, KhuVuc b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public KhuVucColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region KhuVucKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="KhuVuc"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class KhuVucKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the KhuVucKey class.
		/// </summary>
		public KhuVucKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the KhuVucKey class.
		/// </summary>
		public KhuVucKey(KhuVucBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.IdKhuVuc = entity.IdKhuVuc;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the KhuVucKey class.
		/// </summary>
		public KhuVucKey(System.Int64 idKhuVuc)
		{
			#region Init Properties

			this.IdKhuVuc = idKhuVuc;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private KhuVucBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public KhuVucBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the IdKhuVuc property
		private System.Int64 _idKhuVuc;
		
		/// <summary>
		/// Gets or sets the IdKhuVuc property.
		/// </summary>
		public System.Int64 IdKhuVuc
		{
			get { return _idKhuVuc; }
			set
			{
				if ( this.Entity != null )
					this.Entity.IdKhuVuc = value;
				
				_idKhuVuc = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				IdKhuVuc = ( values["IdKhuVuc"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdKhuVuc"], typeof(System.Int64)) : (long)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("IdKhuVuc", IdKhuVuc);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("IdKhuVuc: {0}{1}",
								IdKhuVuc,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region KhuVucColumn Enum
	
	/// <summary>
	/// Enumerate the KhuVuc columns.
	/// </summary>
	[Serializable]
	public enum KhuVucColumn : int
	{
		/// <summary>
		/// IdKhuVuc : 
		/// </summary>
		[EnumTextValue("id_KhuVuc")]
		[ColumnEnum("id_KhuVuc", typeof(System.Int64), System.Data.DbType.Int64, true, false, false)]
		IdKhuVuc = 1,
		/// <summary>
		/// TenKv : 
		/// </summary>
		[EnumTextValue("TenKV")]
		[ColumnEnum("TenKV", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		TenKv = 2,
		/// <summary>
		/// MaKv : 
		/// </summary>
		[EnumTextValue("MaKV")]
		[ColumnEnum("MaKV", typeof(System.Byte[]), System.Data.DbType.Binary, false, false, true)]
		MaKv = 3,
		/// <summary>
		/// MoTa : 
		/// </summary>
		[EnumTextValue("MoTa")]
		[ColumnEnum("MoTa", typeof(System.String), System.Data.DbType.String, false, false, true, 1000)]
		MoTa = 4,
		/// <summary>
		/// Flag : 
		/// </summary>
		[EnumTextValue("Flag")]
		[ColumnEnum("Flag", typeof(System.Byte), System.Data.DbType.Byte, false, false, true)]
		Flag = 5
	}//End enum

	#endregion KhuVucColumn Enum

} // end namespace
