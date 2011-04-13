﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file QuocGia.cs instead.
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
	/// An object representation of the 'tbl_QuocGia' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class QuocGiaBase : EntityBase, traveltips.Entities.IQuocGia, IEntityId<QuocGiaKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private QuocGiaEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private QuocGiaEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private QuocGiaEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<QuocGia> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event QuocGiaEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event QuocGiaEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="QuocGiaBase"/> instance.
		///</summary>
		public QuocGiaBase()
		{
			this.entityData = new QuocGiaEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="QuocGiaBase"/> instance.
		///</summary>
		///<param name="idQuocGia"></param>
		///<param name="tenQg"></param>
		///<param name="maQg"></param>
		///<param name="moTa"></param>
		///<param name="flag"></param>
		public QuocGiaBase(System.Int64 idQuocGia, System.String tenQg, System.String maQg, 
			System.String moTa, System.Byte? flag)
		{
			this.entityData = new QuocGiaEntityData();
			this.backupData = null;

			this.IdQuocGia = idQuocGia;
			this.TenQg = tenQg;
			this.MaQg = maQg;
			this.MoTa = moTa;
			this.Flag = flag;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="QuocGia"/> instance.
		///</summary>
		///<param name="idQuocGia"></param>
		///<param name="tenQg"></param>
		///<param name="maQg"></param>
		///<param name="moTa"></param>
		///<param name="flag"></param>
		public static QuocGia CreateQuocGia(System.Int64 idQuocGia, System.String tenQg, System.String maQg, 
			System.String moTa, System.Byte? flag)
		{
			QuocGia newQuocGia = new QuocGia();
			newQuocGia.IdQuocGia = idQuocGia;
			newQuocGia.TenQg = tenQg;
			newQuocGia.MaQg = maQg;
			newQuocGia.MoTa = moTa;
			newQuocGia.Flag = flag;
			return newQuocGia;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the IdQuocGia property. 
		///		
		/// </summary>
		/// <value>This type is bigint.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false)]
		public virtual System.Int64 IdQuocGia
		{
			get
			{
				return this.entityData.IdQuocGia; 
			}
			
			set
			{
				if (this.entityData.IdQuocGia == value)
					return;
					
				OnColumnChanging(QuocGiaColumn.IdQuocGia, this.entityData.IdQuocGia);
				this.entityData.IdQuocGia = value;
				this.EntityId.IdQuocGia = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(QuocGiaColumn.IdQuocGia, this.entityData.IdQuocGia);
				OnPropertyChanged("IdQuocGia");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the id_QuocGia property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the id_QuocGia property.</remarks>
		/// <value>This type is bigint</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Int64 OriginalIdQuocGia
		{
			get { return this.entityData.OriginalIdQuocGia; }
			set { this.entityData.OriginalIdQuocGia = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the TenQg property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 100)]
		public virtual System.String TenQg
		{
			get
			{
				return this.entityData.TenQg; 
			}
			
			set
			{
				if (this.entityData.TenQg == value)
					return;
					
				OnColumnChanging(QuocGiaColumn.TenQg, this.entityData.TenQg);
				this.entityData.TenQg = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(QuocGiaColumn.TenQg, this.entityData.TenQg);
				OnPropertyChanged("TenQg");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MaQg property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String MaQg
		{
			get
			{
				return this.entityData.MaQg; 
			}
			
			set
			{
				if (this.entityData.MaQg == value)
					return;
					
				OnColumnChanging(QuocGiaColumn.MaQg, this.entityData.MaQg);
				this.entityData.MaQg = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(QuocGiaColumn.MaQg, this.entityData.MaQg);
				OnPropertyChanged("MaQg");
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
					
				OnColumnChanging(QuocGiaColumn.MoTa, this.entityData.MoTa);
				this.entityData.MoTa = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(QuocGiaColumn.MoTa, this.entityData.MoTa);
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
					
				OnColumnChanging(QuocGiaColumn.Flag, this.entityData.Flag);
				this.entityData.Flag = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(QuocGiaColumn.Flag, this.entityData.Flag);
				OnPropertyChanged("Flag");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of ThanhPho objects
		///	which are related to this object through the relation FK_tbl_ThanhPho_tbl_QuocGia
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<ThanhPho> ThanhPhoCollection
		{
			get { return entityData.ThanhPhoCollection; }
			set { entityData.ThanhPhoCollection = value; }	
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
				new Validation.CommonRules.MaxLengthRuleArgs("TenQg", "Ten Qg", 100));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("MaQg", "Ma Qg", 50));
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
			get { return "tbl_QuocGia"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"id_QuocGia", "TenQG", "MaQG", "MoTa", "Flag"};
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
	            this.backupData = this.entityData.Clone() as QuocGiaEntityData;
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
						this.parentCollection.Remove( (QuocGia) this ) ;
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
	            this.parentCollection = value as TList<QuocGia>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as QuocGia);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed QuocGia Entity 
		///</summary>
		public virtual QuocGia Copy()
		{
			//shallow copy entity
			QuocGia copy = new QuocGia();
			copy.SuppressEntityEvents = true;
			copy.IdQuocGia = this.IdQuocGia;
			copy.OriginalIdQuocGia = this.OriginalIdQuocGia;
			copy.TenQg = this.TenQg;
			copy.MaQg = this.MaQg;
			copy.MoTa = this.MoTa;
			copy.Flag = this.Flag;
			
		
			//deep copy nested objects
			copy.ThanhPhoCollection = (TList<ThanhPho>) MakeCopyOf(this.ThanhPhoCollection); 
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
		///  Returns a Typed QuocGia Entity which is a deep copy of the current entity.
		///</summary>
		public virtual QuocGia DeepCopy()
		{
			return EntityHelper.Clone<QuocGia>(this as QuocGia);	
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
				this.entityData = this._originalData.Clone() as QuocGiaEntityData;
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
			this._originalData = this.entityData.Clone() as QuocGiaEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(QuocGiaColumn column)
		{
			switch(column)
			{
					case QuocGiaColumn.IdQuocGia:
					return entityData.IdQuocGia != _originalData.IdQuocGia;
					case QuocGiaColumn.TenQg:
					return entityData.TenQg != _originalData.TenQg;
					case QuocGiaColumn.MaQg:
					return entityData.MaQg != _originalData.MaQg;
					case QuocGiaColumn.MoTa:
					return entityData.MoTa != _originalData.MoTa;
					case QuocGiaColumn.Flag:
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
			result = result || entityData.IdQuocGia != _originalData.IdQuocGia;
			result = result || entityData.TenQg != _originalData.TenQg;
			result = result || entityData.MaQg != _originalData.MaQg;
			result = result || entityData.MoTa != _originalData.MoTa;
			result = result || entityData.Flag != _originalData.Flag;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="QuocGiaBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is QuocGiaBase)
				return Equals(this, (QuocGiaBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="QuocGiaBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.IdQuocGia.GetHashCode() ^ 
					((this.TenQg == null) ? string.Empty : this.TenQg.ToString()).GetHashCode() ^ 
					((this.MaQg == null) ? string.Empty : this.MaQg.ToString()).GetHashCode() ^ 
					((this.MoTa == null) ? string.Empty : this.MoTa.ToString()).GetHashCode() ^ 
					((this.Flag == null) ? string.Empty : this.Flag.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="QuocGiaBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(QuocGiaBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="QuocGiaBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="QuocGiaBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="QuocGiaBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(QuocGiaBase Object1, QuocGiaBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.IdQuocGia != Object2.IdQuocGia)
				equal = false;
			if ( Object1.TenQg != null && Object2.TenQg != null )
			{
				if (Object1.TenQg != Object2.TenQg)
					equal = false;
			}
			else if (Object1.TenQg == null ^ Object2.TenQg == null )
			{
				equal = false;
			}
			if ( Object1.MaQg != null && Object2.MaQg != null )
			{
				if (Object1.MaQg != Object2.MaQg)
					equal = false;
			}
			else if (Object1.MaQg == null ^ Object2.MaQg == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((QuocGiaBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static QuocGiaComparer GetComparer()
        {
            return new QuocGiaComparer();
        }
        */

        // Comparer delegates back to QuocGia
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
        public int CompareTo(QuocGia rhs, QuocGiaColumn which)
        {
            switch (which)
            {
            	
            	
            	case QuocGiaColumn.IdQuocGia:
            		return this.IdQuocGia.CompareTo(rhs.IdQuocGia);
            		
            		                 
            	
            	
            	case QuocGiaColumn.TenQg:
            		return this.TenQg.CompareTo(rhs.TenQg);
            		
            		                 
            	
            	
            	case QuocGiaColumn.MaQg:
            		return this.MaQg.CompareTo(rhs.MaQg);
            		
            		                 
            	
            	
            	case QuocGiaColumn.MoTa:
            		return this.MoTa.CompareTo(rhs.MoTa);
            		
            		                 
            	
            	
            	case QuocGiaColumn.Flag:
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
				
		#region IEntityKey<QuocGiaKey> Members
		
		// member variable for the EntityId property
		private QuocGiaKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual QuocGiaKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new QuocGiaKey(this);
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
					entityTrackingKey = new System.Text.StringBuilder("QuocGia")
					.Append("|").Append( this.IdQuocGia.ToString()).ToString();
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
				"{6}{5}- IdQuocGia: {0}{5}- TenQg: {1}{5}- MaQg: {2}{5}- MoTa: {3}{5}- Flag: {4}{5}", 
				this.IdQuocGia,
				(this.TenQg == null) ? string.Empty : this.TenQg.ToString(),
				(this.MaQg == null) ? string.Empty : this.MaQg.ToString(),
				(this.MoTa == null) ? string.Empty : this.MoTa.ToString(),
				(this.Flag == null) ? string.Empty : this.Flag.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'tbl_QuocGia' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class QuocGiaEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// id_QuocGia : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tbl_QuocGia"</remarks>
			public System.Int64 IdQuocGia;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Int64 OriginalIdQuocGia;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// TenQG : 
		/// </summary>
		public System.String		  TenQg = null;
		
		/// <summary>
		/// MaQG : 
		/// </summary>
		public System.String		  MaQg = null;
		
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

		#region ThanhPhoCollection
		
		private TList<ThanhPho> thanhPhoIdQuocGia;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation thanhPhoIdQuocGia
		/// </summary>	
		public TList<ThanhPho> ThanhPhoCollection
		{
			get
			{
				if (thanhPhoIdQuocGia == null)
				{
				thanhPhoIdQuocGia = new TList<ThanhPho>();
				}
	
				return thanhPhoIdQuocGia;
			}
			set { thanhPhoIdQuocGia = value; }
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
			QuocGiaEntityData _tmp = new QuocGiaEntityData();
						
			_tmp.IdQuocGia = this.IdQuocGia;
			_tmp.OriginalIdQuocGia = this.OriginalIdQuocGia;
			
			_tmp.TenQg = this.TenQg;
			_tmp.MaQg = this.MaQg;
			_tmp.MoTa = this.MoTa;
			_tmp.Flag = this.Flag;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this.thanhPhoIdQuocGia != null)
				_tmp.ThanhPhoCollection = (TList<ThanhPho>) MakeCopyOf(this.ThanhPhoCollection); 
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
		/// <param name="column">The <see cref="QuocGiaColumn"/> which has raised the event.</param>
		public void OnColumnChanging(QuocGiaColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="QuocGiaColumn"/> which has raised the event.</param>
		public void OnColumnChanged(QuocGiaColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="QuocGiaColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(QuocGiaColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				QuocGiaEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new QuocGiaEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="QuocGiaColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(QuocGiaColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				QuocGiaEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new QuocGiaEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region QuocGiaEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="QuocGia"/> object.
	/// </remarks>
	public class QuocGiaEventArgs : System.EventArgs
	{
		private QuocGiaColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the QuocGiaEventArgs class.
		///</summary>
		public QuocGiaEventArgs(QuocGiaColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the QuocGiaEventArgs class.
		///</summary>
		public QuocGiaEventArgs(QuocGiaColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The QuocGiaColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="QuocGiaColumn" />
		public QuocGiaColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all QuocGia related events.
	///</summary>
	public delegate void QuocGiaEventHandler(object sender, QuocGiaEventArgs e);
	
	#region QuocGiaComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class QuocGiaComparer : System.Collections.Generic.IComparer<QuocGia>
	{
		QuocGiaColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:QuocGiaComparer"/> class.
        /// </summary>
		public QuocGiaComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuocGiaComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public QuocGiaComparer(QuocGiaColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="QuocGia"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="QuocGia"/> to compare.</param>
        /// <param name="b">The second <c>QuocGia</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(QuocGia a, QuocGia b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(QuocGia entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(QuocGia a, QuocGia b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public QuocGiaColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region QuocGiaKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="QuocGia"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class QuocGiaKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the QuocGiaKey class.
		/// </summary>
		public QuocGiaKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the QuocGiaKey class.
		/// </summary>
		public QuocGiaKey(QuocGiaBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.IdQuocGia = entity.IdQuocGia;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the QuocGiaKey class.
		/// </summary>
		public QuocGiaKey(System.Int64 idQuocGia)
		{
			#region Init Properties

			this.IdQuocGia = idQuocGia;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private QuocGiaBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public QuocGiaBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the IdQuocGia property
		private System.Int64 _idQuocGia;
		
		/// <summary>
		/// Gets or sets the IdQuocGia property.
		/// </summary>
		public System.Int64 IdQuocGia
		{
			get { return _idQuocGia; }
			set
			{
				if ( this.Entity != null )
					this.Entity.IdQuocGia = value;
				
				_idQuocGia = value;
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
				IdQuocGia = ( values["IdQuocGia"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdQuocGia"], typeof(System.Int64)) : (long)0;
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

			values.Add("IdQuocGia", IdQuocGia);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("IdQuocGia: {0}{1}",
								IdQuocGia,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region QuocGiaColumn Enum
	
	/// <summary>
	/// Enumerate the QuocGia columns.
	/// </summary>
	[Serializable]
	public enum QuocGiaColumn : int
	{
		/// <summary>
		/// IdQuocGia : 
		/// </summary>
		[EnumTextValue("id_QuocGia")]
		[ColumnEnum("id_QuocGia", typeof(System.Int64), System.Data.DbType.Int64, true, false, false)]
		IdQuocGia = 1,
		/// <summary>
		/// TenQg : 
		/// </summary>
		[EnumTextValue("TenQG")]
		[ColumnEnum("TenQG", typeof(System.String), System.Data.DbType.String, false, false, true, 100)]
		TenQg = 2,
		/// <summary>
		/// MaQg : 
		/// </summary>
		[EnumTextValue("MaQG")]
		[ColumnEnum("MaQG", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		MaQg = 3,
		/// <summary>
		/// MoTa : 
		/// </summary>
		[EnumTextValue("MoTa")]
		[ColumnEnum("MoTa", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		MoTa = 4,
		/// <summary>
		/// Flag : 
		/// </summary>
		[EnumTextValue("Flag")]
		[ColumnEnum("Flag", typeof(System.Byte), System.Data.DbType.Byte, false, false, true)]
		Flag = 5
	}//End enum

	#endregion QuocGiaColumn Enum

} // end namespace