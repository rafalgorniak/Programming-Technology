namespace Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
    using Data.API;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Library")]
	internal partial class CatalogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void Insertstate(state instance);
    partial void Updatestate(state instance);
    partial void Deletestate(state instance);
    partial void Insertevent(@event instance);
    partial void Updateevent(@event instance);
    partial void Deleteevent(@event instance);
    partial void Insertbook(book instance);
    partial void Updatebook(book instance);
    partial void Deletebook(book instance);
    #endregion
		
		public CatalogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CatalogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CatalogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CatalogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<state> states
		{
			get
			{
				return this.GetTable<state>();
			}
		}
		
		public System.Data.Linq.Table<@event> events
		{
			get
			{
				return this.GetTable<@event>();
			}
		}
		
		public System.Data.Linq.Table<book> books
		{
			get
			{
				return this.GetTable<book>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	internal partial class user : INotifyPropertyChanging, INotifyPropertyChanged, IUser
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _surname;
		
		private EntitySet<@event> _events;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    #endregion
		
		public user()
		{
			this._events = new EntitySet<@event>(new Action<@event>(this.attach_events), new Action<@event>(this.detach_events));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_event", Storage="_events", ThisKey="id", OtherKey="user_id")]
		public EntitySet<@event> events
		{
			get
			{
				return this._events;
			}
			set
			{
				this._events.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_events(@event entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_events(@event entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.states")]
	internal partial class state : INotifyPropertyChanging, INotifyPropertyChanged, IState
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _book_id;
		
		private string _available;
		
		private EntitySet<@event> _events;
		
		private EntityRef<book> _book;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onbook_idChanging(int value);
    partial void Onbook_idChanged();
    partial void OnavailableChanging(string value);
    partial void OnavailableChanged();
    #endregion
		
		public state()
		{
			this._events = new EntitySet<@event>(new Action<@event>(this.attach_events), new Action<@event>(this.detach_events));
			this._book = default(EntityRef<book>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_book_id", DbType="Int NOT NULL")]
		public int book_id
		{
			get
			{
				return this._book_id;
			}
			set
			{
				if ((this._book_id != value))
				{
					if (this._book.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onbook_idChanging(value);
					this.SendPropertyChanging();
					this._book_id = value;
					this.SendPropertyChanged("book_id");
					this.Onbook_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_available", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string available
		{
			get
			{
				return this._available;
			}
			set
			{
				if ((this._available != value))
				{
					this.OnavailableChanging(value);
					this.SendPropertyChanging();
					this._available = value;
					this.SendPropertyChanged("available");
					this.OnavailableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="state_event", Storage="_events", ThisKey="id", OtherKey="state_id")]
		public EntitySet<@event> events
		{
			get
			{
				return this._events;
			}
			set
			{
				this._events.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="book_state", Storage="_book", ThisKey="book_id", OtherKey="id", IsForeignKey=true)]
		public book book
		{
			get
			{
				return this._book.Entity;
			}
			set
			{
				book previousValue = this._book.Entity;
				if (((previousValue != value) 
							|| (this._book.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._book.Entity = null;
						previousValue.states.Remove(this);
					}
					this._book.Entity = value;
					if ((value != null))
					{
						value.states.Add(this);
						this._book_id = value.id;
					}
					else
					{
						this._book_id = default(int);
					}
					this.SendPropertyChanged("book");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_events(@event entity)
		{
			this.SendPropertyChanging();
			entity.state = this;
		}
		
		private void detach_events(@event entity)
		{
			this.SendPropertyChanging();
			entity.state = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.events")]
	internal partial class @event : INotifyPropertyChanging, INotifyPropertyChanged, IEvent
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _state_id;
		
		private int _user_id;
		
		private string _type;
		
		private EntityRef<state> _state;
		
		private EntityRef<user> _user;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onstate_idChanging(int value);
    partial void Onstate_idChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void OntypeChanging(string value);
    partial void OntypeChanged();
    #endregion
		
		public @event()
		{
			this._state = default(EntityRef<state>);
			this._user = default(EntityRef<user>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_id", DbType="Int NOT NULL")]
		public int state_id
		{
			get
			{
				return this._state_id;
			}
			set
			{
				if ((this._state_id != value))
				{
					if (this._state.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onstate_idChanging(value);
					this.SendPropertyChanging();
					this._state_id = value;
					this.SendPropertyChanged("state_id");
					this.Onstate_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="state_event", Storage="_state", ThisKey="state_id", OtherKey="id", IsForeignKey=true)]
		public state state
		{
			get
			{
				return this._state.Entity;
			}
			set
			{
				state previousValue = this._state.Entity;
				if (((previousValue != value) 
							|| (this._state.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._state.Entity = null;
						previousValue.events.Remove(this);
					}
					this._state.Entity = value;
					if ((value != null))
					{
						value.events.Add(this);
						this._state_id = value.id;
					}
					else
					{
						this._state_id = default(int);
					}
					this.SendPropertyChanged("state");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_event", Storage="_user", ThisKey="user_id", OtherKey="id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.events.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.events.Add(this);
						this._user_id = value.id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("user");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.books")]
	internal partial class book : INotifyPropertyChanging, INotifyPropertyChanged, IBook
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _title;
		
		private string _author;
		
		private EntitySet<state> _states;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnauthorChanging(string value);
    partial void OnauthorChanged();
    #endregion
		
		public book()
		{
			this._states = new EntitySet<state>(new Action<state>(this.attach_states), new Action<state>(this.detach_states));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_author", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string author
		{
			get
			{
				return this._author;
			}
			set
			{
				if ((this._author != value))
				{
					this.OnauthorChanging(value);
					this.SendPropertyChanging();
					this._author = value;
					this.SendPropertyChanged("author");
					this.OnauthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="book_state", Storage="_states", ThisKey="id", OtherKey="book_id")]
		public EntitySet<state> states
		{
			get
			{
				return this._states;
			}
			set
			{
				this._states.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_states(state entity)
		{
			this.SendPropertyChanging();
			entity.book = this;
		}
		
		private void detach_states(state entity)
		{
			this.SendPropertyChanging();
			entity.book = null;
		}
	}
}
#pragma warning restore 1591
