﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Language.cs instead.
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
	/// An object representation of the 'tbl_Language' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class LanguageBase : EntityBase, traveltips.Entities.ILanguage, IEntityId<LanguageKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private LanguageEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private LanguageEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private LanguageEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<Language> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event LanguageEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event LanguageEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="LanguageBase"/> instance.
		///</summary>
		public LanguageBase()
		{
			this.entityData = new LanguageEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="LanguageBase"/> instance.
		///</summary>
		///<param name="tenNn"></param>
		///<param name="maNn"></param>
		///<param name="mota"></param>
		///<param name="flag"></param>
		public LanguageBase(System.String tenNn, System.String maNn, System.String mota, 
			System.Byte? flag)
		{
			this.entityData = new LanguageEntityData();
			this.backupData = null;

			this.TenNn = tenNn;
			this.MaNn = maNn;
			this.Mota = mota;
			this.Flag = flag;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Language"/> instance.
		///</summary>
		///<param name="tenNn"></param>
		///<param name="maNn"></param>
		///<param name="mota"></param>
		///<param name="flag"></param>
		public static Language CreateLanguage(System.String tenNn, System.String maNn, System.String mota, 
			System.Byte? flag)
		{
			Language newLanguage = new Language();
			newLanguage.TenNn = tenNn;
			newLanguage.MaNn = maNn;
			newLanguage.Mota = mota;
			newLanguage.Flag = flag;
			return newLanguage;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the IdLanguage property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 IdLanguage
		{
			get
			{
				return this.entityData.IdLanguage; 
			}
			
			set
			{
				if (this.entityData.IdLanguage == value)
					return;
					
				OnColumnChanging(LanguageColumn.IdLanguage, this.entityData.IdLanguage);
				this.entityData.IdLanguage = value;
				this.EntityId.IdLanguage = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.IdLanguage, this.entityData.IdLanguage);
				OnPropertyChanged("IdLanguage");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the TenNn property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String TenNn
		{
			get
			{
				return this.entityData.TenNn; 
			}
			
			set
			{
				if (this.entityData.TenNn == value)
					return;
					
				OnColumnChanging(LanguageColumn.TenNn, this.entityData.TenNn);
				this.entityData.TenNn = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.TenNn, this.entityData.TenNn);
				OnPropertyChanged("TenNn");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MaNn property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String MaNn
		{
			get
			{
				return this.entityData.MaNn; 
			}
			
			set
			{
				if (this.entityData.MaNn == value)
					return;
					
				OnColumnChanging(LanguageColumn.MaNn, this.entityData.MaNn);
				this.entityData.MaNn = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.MaNn, this.entityData.MaNn);
				OnPropertyChanged("MaNn");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Mota property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String Mota
		{
			get
			{
				return this.entityData.Mota; 
			}
			
			set
			{
				if (this.entityData.Mota == value)
					return;
					
				OnColumnChanging(LanguageColumn.Mota, this.entityData.Mota);
				this.entityData.Mota = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.Mota, this.entityData.Mota);
				OnPropertyChanged("Mota");
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
					
				OnColumnChanging(LanguageColumn.Flag, this.entityData.Flag);
				this.entityData.Flag = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.Flag, this.entityData.Flag);
				OnPropertyChanged("Flag");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of LabelLanguage objects
		///	which are related to this object through the relation FK_tbl_LabelLanguage_tbl_Language
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<LabelLanguage> LabelLanguageCollection
		{
			get { return entityData.LabelLanguageCollection; }
			set { entityData.LabelLanguageCollection = value; }	
		}
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
				new Validation.CommonRules.MaxLengthRuleArgs("TenNn", "Ten Nn", 50));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("MaNn", "Ma Nn", 50));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("Mota", "Mota", 50));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "tbl_Language"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"id_Language", "TenNN", "MaNN", "Mota", "Flag"};
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
	            this.backupData = this.entityData.Clone() as LanguageEntityData;
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
						this.parentCollection.Remove( (Language) this ) ;
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
	            this.parentCollection = value as TList<Language>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Language);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Language Entity 
		///</summary>
		public virtual Language Copy()
		{
			//shallow copy entity
			Language copy = new Language();
			copy.SuppressEntityEvents = true;
			copy.IdLanguage = this.IdLanguage;
			copy.TenNn = this.TenNn;
			copy.MaNn = this.MaNn;
			copy.Mota = this.Mota;
			copy.Flag = this.Flag;
			
		
			//deep copy nested objects
			copy.LabelLanguageCollection = (TList<LabelLanguage>) MakeCopyOf(this.LabelLanguageCollection); 
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
		///  Returns a Typed Language Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Language DeepCopy()
		{
			return EntityHelper.Clone<Language>(this as Language);	
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
				this.entityData = this._originalData.Clone() as LanguageEntityData;
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
			this._originalData = this.entityData.Clone() as LanguageEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(LanguageColumn column)
		{
			switch(column)
			{
					case LanguageColumn.IdLanguage:
					return entityData.IdLanguage != _originalData.IdLanguage;
					case LanguageColumn.TenNn:
					return entityData.TenNn != _originalData.TenNn;
					case LanguageColumn.MaNn:
					return entityData.MaNn != _originalData.MaNn;
					case LanguageColumn.Mota:
					return entityData.Mota != _originalData.Mota;
					case LanguageColumn.Flag:
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
			result = result || entityData.IdLanguage != _originalData.IdLanguage;
			result = result || entityData.TenNn != _originalData.TenNn;
			result = result || entityData.MaNn != _originalData.MaNn;
			result = result || entityData.Mota != _originalData.Mota;
			result = result || entityData.Flag != _originalData.Flag;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="LanguageBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is LanguageBase)
				return Equals(this, (LanguageBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="LanguageBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.IdLanguage.GetHashCode() ^ 
					((this.TenNn == null) ? string.Empty : this.TenNn.ToString()).GetHashCode() ^ 
					((this.MaNn == null) ? string.Empty : this.MaNn.ToString()).GetHashCode() ^ 
					((this.Mota == null) ? string.Empty : this.Mota.ToString()).GetHashCode() ^ 
					((this.Flag == null) ? string.Empty : this.Flag.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="LanguageBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(LanguageBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="LanguageBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="LanguageBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="LanguageBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(LanguageBase Object1, LanguageBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.IdLanguage != Object2.IdLanguage)
				equal = false;
			if ( Object1.TenNn != null && Object2.TenNn != null )
			{
				if (Object1.TenNn != Object2.TenNn)
					equal = false;
			}
			else if (Object1.TenNn == null ^ Object2.TenNn == null )
			{
				equal = false;
			}
			if ( Object1.MaNn != null && Object2.MaNn != null )
			{
				if (Object1.MaNn != Object2.MaNn)
					equal = false;
			}
			else if (Object1.MaNn == null ^ Object2.MaNn == null )
			{
				equal = false;
			}
			if ( Object1.Mota != null && Object2.Mota != null )
			{
				if (Object1.Mota != Object2.Mota)
					equal = false;
			}
			else if (Object1.Mota == null ^ Object2.Mota == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((LanguageBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static LanguageComparer GetComparer()
        {
            return new LanguageComparer();
        }
        */

        // Comparer delegates back to Language
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
        public int CompareTo(Language rhs, LanguageColumn which)
        {
            switch (which)
            {
            	
            	
            	case LanguageColumn.IdLanguage:
            		return this.IdLanguage.CompareTo(rhs.IdLanguage);
            		
            		                 
            	
            	
            	case LanguageColumn.TenNn:
            		return this.TenNn.CompareTo(rhs.TenNn);
            		
            		                 
            	
            	
            	case LanguageColumn.MaNn:
            		return this.MaNn.CompareTo(rhs.MaNn);
            		
            		                 
            	
            	
            	case LanguageColumn.Mota:
            		return this.Mota.CompareTo(rhs.Mota);
            		
            		                 
            	
            	
            	case LanguageColumn.Flag:
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
				
		#region IEntityKey<LanguageKey> Members
		
		// member variable for the EntityId property
		private LanguageKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual LanguageKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new LanguageKey(this);
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
					entityTrackingKey = new System.Text.StringBuilder("Language")
					.Append("|").Append( this.IdLanguage.ToString()).ToString();
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
				"{6}{5}- IdLanguage: {0}{5}- TenNn: {1}{5}- MaNn: {2}{5}- Mota: {3}{5}- Flag: {4}{5}", 
				this.IdLanguage,
				(this.TenNn == null) ? string.Empty : this.TenNn.ToString(),
				(this.MaNn == null) ? string.Empty : this.MaNn.ToString(),
				(this.Mota == null) ? string.Empty : this.Mota.ToString(),
				(this.Flag == null) ? string.Empty : this.Flag.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'tbl_Language' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class LanguageEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// id_Language : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tbl_Language"</remarks>
			public System.Int32 IdLanguage;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// TenNN : 
		/// </summary>
		public System.String		  TenNn = null;
		
		/// <summary>
		/// MaNN : 
		/// </summary>
		public System.String		  MaNn = null;
		
		/// <summary>
		/// Mota : 
		/// </summary>
		public System.String		  Mota = null;
		
		/// <summary>
		/// Flag : 
		/// </summary>
		public System.Byte?		  Flag = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#region LabelLanguageCollection
		
		private TList<LabelLanguage> labelLanguageIdLanguage;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation labelLanguageIdLanguage
		/// </summary>	
		public TList<LabelLanguage> LabelLanguageCollection
		{
			get
			{
				if (labelLanguageIdLanguage == null)
				{
				labelLanguageIdLanguage = new TList<LabelLanguage>();
				}
	
				return labelLanguageIdLanguage;
			}
			set { labelLanguageIdLanguage = value; }
		}
		
		#endregion

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			LanguageEntityData _tmp = new LanguageEntityData();
						
			_tmp.IdLanguage = this.IdLanguage;
			
			_tmp.TenNn = this.TenNn;
			_tmp.MaNn = this.MaNn;
			_tmp.Mota = this.Mota;
			_tmp.Flag = this.Flag;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this.labelLanguageIdLanguage != null)
				_tmp.LabelLanguageCollection = (TList<LabelLanguage>) MakeCopyOf(this.LabelLanguageCollection); 
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
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		public void OnColumnChanging(LanguageColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		public void OnColumnChanged(LanguageColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(LanguageColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				LanguageEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new LanguageEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(LanguageColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				LanguageEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new LanguageEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region LanguageEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Language"/> object.
	/// </remarks>
	public class LanguageEventArgs : System.EventArgs
	{
		private LanguageColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the LanguageEventArgs class.
		///</summary>
		public LanguageEventArgs(LanguageColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the LanguageEventArgs class.
		///</summary>
		public LanguageEventArgs(LanguageColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The LanguageColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="LanguageColumn" />
		public LanguageColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all Language related events.
	///</summary>
	public delegate void LanguageEventHandler(object sender, LanguageEventArgs e);
	
	#region LanguageComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class LanguageComparer : System.Collections.Generic.IComparer<Language>
	{
		LanguageColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:LanguageComparer"/> class.
        /// </summary>
		public LanguageComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LanguageComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public LanguageComparer(LanguageColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Language"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Language"/> to compare.</param>
        /// <param name="b">The second <c>Language</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Language a, Language b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Language entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Language a, Language b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public LanguageColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region LanguageKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Language"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class LanguageKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the LanguageKey class.
		/// </summary>
		public LanguageKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the LanguageKey class.
		/// </summary>
		public LanguageKey(LanguageBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.IdLanguage = entity.IdLanguage;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the LanguageKey class.
		/// </summary>
		public LanguageKey(System.Int32 idLanguage)
		{
			#region Init Properties

			this.IdLanguage = idLanguage;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private LanguageBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public LanguageBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the IdLanguage property
		private System.Int32 _idLanguage;
		
		/// <summary>
		/// Gets or sets the IdLanguage property.
		/// </summary>
		public System.Int32 IdLanguage
		{
			get { return _idLanguage; }
			set
			{
				if ( this.Entity != null )
					this.Entity.IdLanguage = value;
				
				_idLanguage = value;
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
				IdLanguage = ( values["IdLanguage"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdLanguage"], typeof(System.Int32)) : (int)0;
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

			values.Add("IdLanguage", IdLanguage);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("IdLanguage: {0}{1}",
								IdLanguage,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region LanguageColumn Enum
	
	/// <summary>
	/// Enumerate the Language columns.
	/// </summary>
	[Serializable]
	public enum LanguageColumn : int
	{
		/// <summary>
		/// IdLanguage : 
		/// </summary>
		[EnumTextValue("id_Language")]
		[ColumnEnum("id_Language", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		IdLanguage = 1,
		/// <summary>
		/// TenNn : 
		/// </summary>
		[EnumTextValue("TenNN")]
		[ColumnEnum("TenNN", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		TenNn = 2,
		/// <summary>
		/// MaNn : 
		/// </summary>
		[EnumTextValue("MaNN")]
		[ColumnEnum("MaNN", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		MaNn = 3,
		/// <summary>
		/// Mota : 
		/// </summary>
		[EnumTextValue("Mota")]
		[ColumnEnum("Mota", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		Mota = 4,
		/// <summary>
		/// Flag : 
		/// </summary>
		[EnumTextValue("Flag")]
		[ColumnEnum("Flag", typeof(System.Byte), System.Data.DbType.Byte, false, false, true)]
		Flag = 5
	}//End enum

	#endregion LanguageColumn Enum

} // end namespace
