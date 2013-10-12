﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("JSInquisitorModel", "FK_ErrorBases_Users", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Repositories.EntityModel.User), "ErrorBas", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Repositories.EntityModel.ErrorBas), true)]
[assembly: EdmRelationshipAttribute("JSInquisitorModel", "FK_Errors_ErrorBases", "ErrorBas", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Repositories.EntityModel.ErrorBas), "Error", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Repositories.EntityModel.Error), true)]
[assembly: EdmRelationshipAttribute("JSInquisitorModel", "FK_Events_Errors", "Error", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Repositories.EntityModel.Error), "Event", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Repositories.EntityModel.Event), true)]

#endregion

namespace Repositories.EntityModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class JSInquisitorEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new JSInquisitorEntities object using the connection string found in the 'JSInquisitorEntities' section of the application configuration file.
        /// </summary>
        public JSInquisitorEntities() : base("name=JSInquisitorEntities", "JSInquisitorEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new JSInquisitorEntities object.
        /// </summary>
        public JSInquisitorEntities(string connectionString) : base(connectionString, "JSInquisitorEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new JSInquisitorEntities object.
        /// </summary>
        public JSInquisitorEntities(EntityConnection connection) : base(connection, "JSInquisitorEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ErrorBas> ErrorBases
        {
            get
            {
                if ((_ErrorBases == null))
                {
                    _ErrorBases = base.CreateObjectSet<ErrorBas>("ErrorBases");
                }
                return _ErrorBases;
            }
        }
        private ObjectSet<ErrorBas> _ErrorBases;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Error> Errors
        {
            get
            {
                if ((_Errors == null))
                {
                    _Errors = base.CreateObjectSet<Error>("Errors");
                }
                return _Errors;
            }
        }
        private ObjectSet<Error> _Errors;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Event> Events
        {
            get
            {
                if ((_Events == null))
                {
                    _Events = base.CreateObjectSet<Event>("Events");
                }
                return _Events;
            }
        }
        private ObjectSet<Event> _Events;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ErrorBases EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToErrorBases(ErrorBas errorBas)
        {
            base.AddObject("ErrorBases", errorBas);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Errors EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToErrors(Error error)
        {
            base.AddObject("Errors", error);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Events EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEvents(Event @event)
        {
            base.AddObject("Events", @event);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JSInquisitorModel", Name="Error")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Error : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Error object.
        /// </summary>
        /// <param name="errorId">Initial value of the ErrorId property.</param>
        /// <param name="errorBaseId">Initial value of the ErrorBaseId property.</param>
        /// <param name="time">Initial value of the Time property.</param>
        public static Error CreateError(global::System.Guid errorId, global::System.Guid errorBaseId, global::System.DateTime time)
        {
            Error error = new Error();
            error.ErrorId = errorId;
            error.ErrorBaseId = errorBaseId;
            error.Time = time;
            return error;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ErrorId
        {
            get
            {
                return _ErrorId;
            }
            set
            {
                if (_ErrorId != value)
                {
                    OnErrorIdChanging(value);
                    ReportPropertyChanging("ErrorId");
                    _ErrorId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ErrorId");
                    OnErrorIdChanged();
                }
            }
        }
        private global::System.Guid _ErrorId;
        partial void OnErrorIdChanging(global::System.Guid value);
        partial void OnErrorIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Agent
        {
            get
            {
                return _Agent;
            }
            set
            {
                OnAgentChanging(value);
                ReportPropertyChanging("Agent");
                _Agent = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Agent");
                OnAgentChanged();
            }
        }
        private global::System.String _Agent;
        partial void OnAgentChanging(global::System.String value);
        partial void OnAgentChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FileUrl
        {
            get
            {
                return _FileUrl;
            }
            set
            {
                OnFileUrlChanging(value);
                ReportPropertyChanging("FileUrl");
                _FileUrl = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FileUrl");
                OnFileUrlChanged();
            }
        }
        private global::System.String _FileUrl;
        partial void OnFileUrlChanging(global::System.String value);
        partial void OnFileUrlChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PageUrl
        {
            get
            {
                return _PageUrl;
            }
            set
            {
                OnPageUrlChanging(value);
                ReportPropertyChanging("PageUrl");
                _PageUrl = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PageUrl");
                OnPageUrlChanged();
            }
        }
        private global::System.String _PageUrl;
        partial void OnPageUrlChanging(global::System.String value);
        partial void OnPageUrlChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Line
        {
            get
            {
                return _Line;
            }
            set
            {
                OnLineChanging(value);
                ReportPropertyChanging("Line");
                _Line = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Line");
                OnLineChanged();
            }
        }
        private Nullable<global::System.Int32> _Line;
        partial void OnLineChanging(Nullable<global::System.Int32> value);
        partial void OnLineChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Stack
        {
            get
            {
                return _Stack;
            }
            set
            {
                OnStackChanging(value);
                ReportPropertyChanging("Stack");
                _Stack = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Stack");
                OnStackChanged();
            }
        }
        private global::System.String _Stack;
        partial void OnStackChanging(global::System.String value);
        partial void OnStackChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ErrorBaseId
        {
            get
            {
                return _ErrorBaseId;
            }
            set
            {
                OnErrorBaseIdChanging(value);
                ReportPropertyChanging("ErrorBaseId");
                _ErrorBaseId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ErrorBaseId");
                OnErrorBaseIdChanged();
            }
        }
        private global::System.Guid _ErrorBaseId;
        partial void OnErrorBaseIdChanging(global::System.Guid value);
        partial void OnErrorBaseIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Time
        {
            get
            {
                return _Time;
            }
            set
            {
                OnTimeChanging(value);
                ReportPropertyChanging("Time");
                _Time = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Time");
                OnTimeChanged();
            }
        }
        private global::System.DateTime _Time;
        partial void OnTimeChanging(global::System.DateTime value);
        partial void OnTimeChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JSInquisitorModel", "FK_Errors_ErrorBases", "ErrorBas")]
        public ErrorBas ErrorBas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ErrorBas>("JSInquisitorModel.FK_Errors_ErrorBases", "ErrorBas").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ErrorBas>("JSInquisitorModel.FK_Errors_ErrorBases", "ErrorBas").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<ErrorBas> ErrorBasReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ErrorBas>("JSInquisitorModel.FK_Errors_ErrorBases", "ErrorBas");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<ErrorBas>("JSInquisitorModel.FK_Errors_ErrorBases", "ErrorBas", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JSInquisitorModel", "FK_Events_Errors", "Event")]
        public EntityCollection<Event> Events
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Event>("JSInquisitorModel.FK_Events_Errors", "Event");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Event>("JSInquisitorModel.FK_Events_Errors", "Event", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JSInquisitorModel", Name="ErrorBas")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ErrorBas : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ErrorBas object.
        /// </summary>
        /// <param name="errorBaseId">Initial value of the ErrorBaseId property.</param>
        /// <param name="message">Initial value of the Message property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        public static ErrorBas CreateErrorBas(global::System.Guid errorBaseId, global::System.String message, global::System.Guid userId)
        {
            ErrorBas errorBas = new ErrorBas();
            errorBas.ErrorBaseId = errorBaseId;
            errorBas.Message = message;
            errorBas.UserId = userId;
            return errorBas;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ErrorBaseId
        {
            get
            {
                return _ErrorBaseId;
            }
            set
            {
                if (_ErrorBaseId != value)
                {
                    OnErrorBaseIdChanging(value);
                    ReportPropertyChanging("ErrorBaseId");
                    _ErrorBaseId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ErrorBaseId");
                    OnErrorBaseIdChanged();
                }
            }
        }
        private global::System.Guid _ErrorBaseId;
        partial void OnErrorBaseIdChanging(global::System.Guid value);
        partial void OnErrorBaseIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Message
        {
            get
            {
                return _Message;
            }
            set
            {
                OnMessageChanging(value);
                ReportPropertyChanging("Message");
                _Message = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Message");
                OnMessageChanged();
            }
        }
        private global::System.String _Message;
        partial void OnMessageChanging(global::System.String value);
        partial void OnMessageChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JSInquisitorModel", "FK_ErrorBases_Users", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("JSInquisitorModel.FK_ErrorBases_Users", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("JSInquisitorModel.FK_ErrorBases_Users", "User").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("JSInquisitorModel.FK_ErrorBases_Users", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("JSInquisitorModel.FK_ErrorBases_Users", "User", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JSInquisitorModel", "FK_Errors_ErrorBases", "Error")]
        public EntityCollection<Error> Errors
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Error>("JSInquisitorModel.FK_Errors_ErrorBases", "Error");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Error>("JSInquisitorModel.FK_Errors_ErrorBases", "Error", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JSInquisitorModel", Name="Event")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Event : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Event object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="eventType">Initial value of the EventType property.</param>
        /// <param name="target">Initial value of the Target property.</param>
        /// <param name="timeAfterStart">Initial value of the TimeAfterStart property.</param>
        /// <param name="errorId">Initial value of the ErrorId property.</param>
        public static Event CreateEvent(global::System.Guid id, global::System.Int32 eventType, global::System.String target, global::System.Int32 timeAfterStart, global::System.Guid errorId)
        {
            Event @event = new Event();
            @event.Id = id;
            @event.EventType = eventType;
            @event.Target = target;
            @event.TimeAfterStart = timeAfterStart;
            @event.ErrorId = errorId;
            return @event;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 EventType
        {
            get
            {
                return _EventType;
            }
            set
            {
                OnEventTypeChanging(value);
                ReportPropertyChanging("EventType");
                _EventType = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EventType");
                OnEventTypeChanged();
            }
        }
        private global::System.Int32 _EventType;
        partial void OnEventTypeChanging(global::System.Int32 value);
        partial void OnEventTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Target
        {
            get
            {
                return _Target;
            }
            set
            {
                OnTargetChanging(value);
                ReportPropertyChanging("Target");
                _Target = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Target");
                OnTargetChanged();
            }
        }
        private global::System.String _Target;
        partial void OnTargetChanging(global::System.String value);
        partial void OnTargetChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TimeAfterStart
        {
            get
            {
                return _TimeAfterStart;
            }
            set
            {
                OnTimeAfterStartChanging(value);
                ReportPropertyChanging("TimeAfterStart");
                _TimeAfterStart = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TimeAfterStart");
                OnTimeAfterStartChanged();
            }
        }
        private global::System.Int32 _TimeAfterStart;
        partial void OnTimeAfterStartChanging(global::System.Int32 value);
        partial void OnTimeAfterStartChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ErrorId
        {
            get
            {
                return _ErrorId;
            }
            set
            {
                OnErrorIdChanging(value);
                ReportPropertyChanging("ErrorId");
                _ErrorId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ErrorId");
                OnErrorIdChanged();
            }
        }
        private global::System.Guid _ErrorId;
        partial void OnErrorIdChanging(global::System.Guid value);
        partial void OnErrorIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JSInquisitorModel", "FK_Events_Errors", "Error")]
        public Error Error
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Error>("JSInquisitorModel.FK_Events_Errors", "Error").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Error>("JSInquisitorModel.FK_Events_Errors", "Error").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Error> ErrorReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Error>("JSInquisitorModel.FK_Events_Errors", "Error");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Error>("JSInquisitorModel.FK_Events_Errors", "Error", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JSInquisitorModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="email">Initial value of the Email property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        public static User CreateUser(global::System.Guid id, global::System.String email, global::System.Guid password)
        {
            User user = new User();
            user.Id = id;
            user.Email = email;
            user.Password = password;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.Guid _Password;
        partial void OnPasswordChanging(global::System.Guid value);
        partial void OnPasswordChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JSInquisitorModel", "FK_ErrorBases_Users", "ErrorBas")]
        public EntityCollection<ErrorBas> ErrorBases
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ErrorBas>("JSInquisitorModel.FK_ErrorBases_Users", "ErrorBas");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ErrorBas>("JSInquisitorModel.FK_ErrorBases_Users", "ErrorBas", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
