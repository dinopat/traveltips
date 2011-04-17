﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file LabelNn.cs instead.
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
	/// An object representation of the 'tbl_LabelNN' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class LabelNnBase : EntityBase, traveltips.Entities.ILabelNn, IEntityId<LabelNnKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private LabelNnEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private LabelNnEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private LabelNnEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<LabelNn> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event LabelNnEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event LabelNnEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="LabelNnBase"/> instance.
		///</summary>
		public LabelNnBase()
		{
			this.entityData = new LabelNnEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="LabelNnBase"/> instance.
		///</summary>
		///<param name="idLabel"></param>
		///<param name="maLabel"></param>
		///<param name="tenLabel"></param>
		///<param name="moTa"></param>
		///<param name="flag"></param>
		public LabelNnBase(System.Int64 idLabel, System.String maLabel, System.String tenLabel, 
			System.String moTa, System.Byte? flag)
		{
			this.entityData = new LabelNnEntityData();
			this.backupData = null;

			this.IdLabel = idLabel;
			this.MaLabel = maLabel;
			this.TenLabel = tenLabel;
			this.MoTa = moTa;
			this.Flag = flag;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="LabelNn"/> instance.
		///</summary>
		///<param name="idLabel"></param>
		///<param name="maLabel"></param>
		///<param name="tenLabel"></param>
		///<param name="moTa"></param>
		///<param name="flag"></param>
		public static LabelNn CreateLabelNn(System.Int64 idLabel, System.String maLabel, System.String tenLabel, 
			System.String moTa, System.Byte? flag)
		{
			LabelNn newLabelNn = new LabelNn();
			newLabelNn.IdLabel = idLabel;
			newLabelNn.MaLabel = maLabel;
			newLabelNn.TenLabel = tenLabel;
			newLabelNn.MoTa = moTa;
			newLabelNn.Flag = flag;
			return newLabelNn;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the IdLabel property. 
		///		
		/// </summary>
		/// <value>This type is bigint.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false)]
		public virtual System.Int64 IdLabel
		{
			get
			{
				return this.entityData.IdLabel; 
			}
			
			set
			{
				if (this.entityData.IdLabel == value)
					return;
					
				OnColumnChanging(LabelNnColumn.IdLabel, this.entityData.IdLabel);
				this.entityData.IdLabel = value;
				this.EntityId.IdLabel = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LabelNnColumn.IdLabel, this.entityData.IdLabel);
				OnPropertyChanged("IdLabel");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the id_Label property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the id_Label property.</remarks>
		/// <value>This type is bigint</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Int64 OriginalIdLabel
		{
			get { return this.entityData.OriginalIdLabel; }
			set { this.entityData.OriginalIdLabel = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the MaLabel property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String MaLabel
		{
			get
			{
				return this.entityData.MaLabel; 
			}
			
			set
			{
				if (this.entityData.MaLabel == value)
					return;
					
				OnColumnChanging(LabelNnColumn.MaLabel, this.entityData.MaLabel);
				this.entityData.MaLabel = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LabelNnColumn.MaLabel, this.entityData.MaLabel);
				OnPropertyChanged("MaLabel");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the TenLabel property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String TenLabel
		{
			get
			{
				return this.entityData.TenLabel; 
			}
			
			set
			{
				if (this.entityData.TenLabel == value)
					return;
					
				OnColumnChanging(LabelNnColumn.TenLabel, this.entityData.TenLabel);
				this.entityData.TenLabel = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LabelNnColumn.TenLabel, this.entityData.TenLabel);
				OnPropertyChanged("TenLabel");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MoTa property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
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
					
				OnColumnChanging(LabelNnColumn.MoTa, this.entityData.MoTa);
				this.entityData.MoTa = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LabelNnColumn.MoTa, this.entityData.MoTa);
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
					
				OnColumnChanging(LabelNnColumn.Flag, this.entityData.Flag);
				this.entityData.Flag = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LabelNnColumn.Flag, this.entityData.Flag);
				OnPropertyChanged("Flag");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of LabelLanguage objects
		///	which are related to this object through the relation FK_tbl_LabelLanguage_tbl_Label
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
				new Validation.CommonRules.MaxLengthRuleArgs("MaLabel", "Ma Label", 50));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("TenLabel", "Ten Label", 50));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("MoTa", "Mo Ta", 50));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "tbl_LabelNN"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"id_Label", "MaLabel", "TenLabel", "MoTa", "Flag"};
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
	            this.backupData = this.entityData.Clone() as LabelNnEntityData;
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
						this.parentCollection.Remove( (LabelNn) this ) ;
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
	            this.parentCollection = value as TList<LabelNn>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as LabelNn);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed LabelNn Entity 
		///</summary>
		public virtual LabelNn Copy()
		{
			//shallow copy entity
			LabelNn copy = new LabelNn();
			copy.SuppressEntityEvents = true;
			copy.IdLabel = this.IdLabel;
			copy.OriginalIdLabel = this.OriginalIdLabel;
			copy.MaLabel = this.MaLabel;
			copy.TenLabel = this.TenLabel;
			copy.MoTa = this.MoTa;
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
		///  Returns a Typed LabelNn Entity which is a deep copy of the current entity.
		///</summary>
		public virtual LabelNn DeepCopy()
		{
			return EntityHelper.Clone<LabelNn>(this as LabelNn);	
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
				this.entityData = this._originalData.Clone() as LabelNnEntityData;
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
			this._originalData = this.entityData.Clone() as LabelNnEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(LabelNnColumn column)
		{
			switch(column)
			{
					case LabelNnColumn.IdLabel:
					return entityData.IdLabel != _originalData.IdLabel;
					case LabelNnColumn.MaLabel:
					return entityData.MaLabel != _originalData.MaLabel;
					case LabelNnColumn.TenLabel:
					return entityData.TenLabel != _originalData.TenLabel;
					case LabelNnColumn.MoTa:
					return entityData.MoTa != _originalData.MoTa;
					case LabelNnColumn.Flag:
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
			result = result || entityData.IdLabel != _originalData.IdLabel;
			result = result || entityData.MaLabel != _originalData.MaLabel;
			result = result || entityData.TenLabel != _originalData.TenLabel;
			result = result || entityData.MoTa != _originalData.MoTa;
			result = result || entityData.Flag != _originalData.Flag;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="LabelNnBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is LabelNnBase)
				return Equals(this, (LabelNnBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="LabelNnBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.IdLabel.GetHashCode() ^ 
					((this.MaLabel == null) ? string.Empty : this.MaLabel.ToString()).GetHashCode() ^ 
					((this.TenLabel == null) ? string.Empty : this.TenLabel.ToString()).GetHashCode() ^ 
					((this.MoTa == null) ? string.Empty : this.MoTa.ToString()).GetHashCode() ^ 
					((this.Flag == null) ? string.Empty : this.Flag.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="LabelNnBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(LabelNnBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="LabelNnBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="LabelNnBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="LabelNnBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(LabelNnBase Object1, LabelNnBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.IdLabel != Object2.IdLabel)
				equal = false;
			if ( Object1.MaLabel != null && Object2.MaLabel != null )
			{
				if (Object1.MaLabel != Object2.MaLabel)
					equal = false;
			}
			else if (Object1.MaLabel == null ^ Object2.MaLabel == null )
			{
				equal = false;
			}
			if ( Object1.TenLabel != null && Object2.TenLabel != null )
			{
				if (Object1.TenLabel != Object2.TenLabel)
					equal = false;
			}
			else if (Object1.TenLabel == null ^ Object2.TenLabel == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((LabelNnBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static LabelNnComparer GetComparer()
        {
            return new LabelNnComparer();
        }
        */

        // Comparer delegates back to LabelNn
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
        public int CompareTo(LabelNn rhs, LabelNnColumn which)
        {
            switch (which)
            {
            	
            	
            	case LabelNnColumn.IdLabel:
            		return this.IdLabel.CompareTo(rhs.IdLabel);
            		
            		                 
            	
            	
            	case LabelNnColumn.MaLabel:
            		return this.MaLabel.CompareTo(rhs.MaLabel);
            		
            		                 
            	
            	
            	case LabelNnColumn.TenLabel:
            		return this.TenLabel.CompareTo(rhs.TenLabel);
            		
            		                 
            	
            	
            	case LabelNnColumn.MoTa:
            		return this.MoTa.CompareTo(rhs.MoTa);
            		
            		                 
            	
            	
            	case LabelNnColumn.Flag:
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
				
		#region IEntityKey<LabelNnKey> Members
		
		// member variable for the EntityId property
		private LabelNnKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual LabelNnKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new LabelNnKey(this);
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
					entityTrackingKey = new System.Text.StringBuilder("LabelNn")
					.Append("|").Append( this.IdLabel.ToString()).ToString();
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
				"{6}{5}- IdLabel: {0}{5}- MaLabel: {1}{5}- TenLabel: {2}{5}- MoTa: {3}{5}- Flag: {4}{5}", 
				this.IdLabel,
				(this.MaLabel == null) ? string.Empty : this.MaLabel.ToString(),
				(this.TenLabel == null) ? string.Empty : this.TenLabel.ToString(),
				(this.MoTa == null) ? string.Empty : this.MoTa.ToString(),
				(this.Flag == null) ? string.Empty : this.Flag.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'tbl_LabelNN' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class LabelNnEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// id_Label : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tbl_LabelNN"</remarks>
			public System.Int64 IdLabel;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Int64 OriginalIdLabel;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// MaLabel : 
		/// </summary>
		public System.String		  MaLabel = null;
		
		/// <summary>
		/// TenLabel : 
		/// </summary>
		public System.String		  TenLabel = null;
		
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

		#region LabelLanguageCollection
		
		private TList<LabelLanguage> labelLanguageIdLabel;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation labelLanguageIdLabel
		/// </summary>	
		public TList<LabelLanguage> LabelLanguageCollection
		{
			get
			{
				if (labelLanguageIdLabel == null)
				{
				labelLanguageIdLabel = new TList<LabelLanguage>();
				}
	
				return labelLanguageIdLabel;
			}
			set { labelLanguageIdLabel = value; }
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
			LabelNnEntityData _tmp = new LabelNnEntityData();
						
			_tmp.IdLabel = this.IdLabel;
			_tmp.OriginalIdLabel = this.OriginalIdLabel;
			
			_tmp.MaLabel = this.MaLabel;
			_tmp.TenLabel = this.TenLabel;
			_tmp.MoTa = this.MoTa;
			_tmp.Flag = this.Flag;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this.labelLanguageIdLabel != null)
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
		/// <param name="column">The <see cref="LabelNnColumn"/> which has raised the event.</param>
		public void OnColumnChanging(LabelNnColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LabelNnColumn"/> which has raised the event.</param>
		public void OnColumnChanged(LabelNnColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LabelNnColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(LabelNnColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				LabelNnEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new LabelNnEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LabelNnColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(LabelNnColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				LabelNnEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new LabelNnEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region LabelNnEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="LabelNn"/> object.
	/// </remarks>
	public class LabelNnEventArgs : System.EventArgs
	{
		private LabelNnColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the LabelNnEventArgs class.
		///</summary>
		public LabelNnEventArgs(LabelNnColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the LabelNnEventArgs class.
		///</summary>
		public LabelNnEventArgs(LabelNnColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The LabelNnColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="LabelNnColumn" />
		public LabelNnColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all LabelNn related events.
	///</summary>
	public delegate void LabelNnEventHandler(object sender, LabelNnEventArgs e);
	
	#region LabelNnComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class LabelNnComparer : System.Collections.Generic.IComparer<LabelNn>
	{
		LabelNnColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:LabelNnComparer"/> class.
        /// </summary>
		public LabelNnComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LabelNnComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public LabelNnComparer(LabelNnColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="LabelNn"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="LabelNn"/> to compare.</param>
        /// <param name="b">The second <c>LabelNn</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(LabelNn a, LabelNn b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(LabelNn entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(LabelNn a, LabelNn b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public LabelNnColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region LabelNnKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="LabelNn"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class LabelNnKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the LabelNnKey class.
		/// </summary>
		public LabelNnKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the LabelNnKey class.
		/// </summary>
		public LabelNnKey(LabelNnBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.IdLabel = entity.IdLabel;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the LabelNnKey class.
		/// </summary>
		public LabelNnKey(System.Int64 idLabel)
		{
			#region Init Properties

			this.IdLabel = idLabel;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private LabelNnBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public LabelNnBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the IdLabel property
		private System.Int64 _idLabel;
		
		/// <summary>
		/// Gets or sets the IdLabel property.
		/// </summary>
		public System.Int64 IdLabel
		{
			get { return _idLabel; }
			set
			{
				if ( this.Entity != null )
					this.Entity.IdLabel = value;
				
				_idLabel = value;
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
				IdLabel = ( values["IdLabel"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLabel"], typeof(System.Int64)) : (long)0;
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

			values.Add("IdLabel", IdLabel);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("IdLabel: {0}{1}",
								IdLabel,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region LabelNnColumn Enum
	
	/// <summary>
	/// Enumerate the LabelNn columns.
	/// </summary>
	[Serializable]
	public enum LabelNnColumn : int
	{
		/// <summary>
		/// IdLabel : 
		/// </summary>
		[EnumTextValue("id_Label")]
		[ColumnEnum("id_Label", typeof(System.Int64), System.Data.DbType.Int64, true, false, false)]
		IdLabel = 1,
		/// <summary>
		/// MaLabel : 
		/// </summary>
		[EnumTextValue("MaLabel")]
		[ColumnEnum("MaLabel", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		MaLabel = 2,
		/// <summary>
		/// TenLabel : 
		/// </summary>
		[EnumTextValue("TenLabel")]
		[ColumnEnum("TenLabel", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		TenLabel = 3,
		/// <summary>
		/// MoTa : 
		/// </summary>
		[EnumTextValue("MoTa")]
		[ColumnEnum("MoTa", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		MoTa = 4,
		/// <summary>
		/// Flag : 
		/// </summary>
		[EnumTextValue("Flag")]
		[ColumnEnum("Flag", typeof(System.Byte), System.Data.DbType.Byte, false, false, true)]
		Flag = 5
	}//End enum

	#endregion LabelNnColumn Enum

} // end namespace