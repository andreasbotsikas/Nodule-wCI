//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 6/7/2013 1:36:06 πμ
namespace Nodule_wCI.Worker.NoduleDb
{
    
    /// <summary>
    /// There are no comments for NoduleDbEntities in the schema.
    /// </summary>
    public partial class NoduleDbEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new NoduleDbEntities object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public NoduleDbEntities(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("NoduleDbModel", global::System.StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("Nodule_wCI.Worker.NoduleDb", typeName.Substring(13)), false);
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("Nodule_wCI.Worker.NoduleDb", global::System.StringComparison.Ordinal))
            {
                return string.Concat("NoduleDbModel.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Commits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Commits> Commits
        {
            get
            {
                if ((this._Commits == null))
                {
                    this._Commits = base.CreateQuery<Commits>("Commits");
                }
                return this._Commits;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Commits> _Commits;
        /// <summary>
        /// There are no comments for PostStatuses in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<PostStatuses> PostStatuses
        {
            get
            {
                if ((this._PostStatuses == null))
                {
                    this._PostStatuses = base.CreateQuery<PostStatuses>("PostStatuses");
                }
                return this._PostStatuses;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<PostStatuses> _PostStatuses;
        /// <summary>
        /// There are no comments for WebHookPostCommits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<WebHookPostCommits> WebHookPostCommits
        {
            get
            {
                if ((this._WebHookPostCommits == null))
                {
                    this._WebHookPostCommits = base.CreateQuery<WebHookPostCommits>("WebHookPostCommits");
                }
                return this._WebHookPostCommits;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<WebHookPostCommits> _WebHookPostCommits;
        /// <summary>
        /// There are no comments for WebHookPosts in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<WebHookPosts> WebHookPosts
        {
            get
            {
                if ((this._WebHookPosts == null))
                {
                    this._WebHookPosts = base.CreateQuery<WebHookPosts>("WebHookPosts");
                }
                return this._WebHookPosts;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<WebHookPosts> _WebHookPosts;
        /// <summary>
        /// There are no comments for Commits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCommits(Commits commits)
        {
            base.AddObject("Commits", commits);
        }
        /// <summary>
        /// There are no comments for PostStatuses in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToPostStatuses(PostStatuses postStatuses)
        {
            base.AddObject("PostStatuses", postStatuses);
        }
        /// <summary>
        /// There are no comments for WebHookPostCommits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToWebHookPostCommits(WebHookPostCommits webHookPostCommits)
        {
            base.AddObject("WebHookPostCommits", webHookPostCommits);
        }
        /// <summary>
        /// There are no comments for WebHookPosts in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToWebHookPosts(WebHookPosts webHookPosts)
        {
            base.AddObject("WebHookPosts", webHookPosts);
        }
    }
    /// <summary>
    /// There are no comments for NoduleDbModel.Commits in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Commits")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class Commits : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Commits object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="modifiedNo">Initial value of ModifiedNo.</param>
        /// <param name="addedNo">Initial value of AddedNo.</param>
        /// <param name="deletedNo">Initial value of DeletedNo.</param>
        /// <param name="date">Initial value of Date.</param>
        /// <param name="url">Initial value of Url.</param>
        /// <param name="message">Initial value of Message.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Commits CreateCommits(string ID, int modifiedNo, int addedNo, int deletedNo, global::System.DateTime date, string url, string message)
        {
            Commits commits = new Commits();
            commits.Id = ID;
            commits.ModifiedNo = modifiedNo;
            commits.AddedNo = addedNo;
            commits.DeletedNo = deletedNo;
            commits.Date = date;
            commits.Url = url;
            commits.Message = message;
            return commits;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Id;
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Email in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnEmailChanging(value);
                this._Email = value;
                this.OnEmailChanged();
                this.OnPropertyChanged("Email");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Email;
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this._Name = value;
                this.OnNameChanged();
                this.OnPropertyChanged("Name");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Property Username in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                this.OnUsernameChanging(value);
                this._Username = value;
                this.OnUsernameChanged();
                this.OnPropertyChanged("Username");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Username;
        partial void OnUsernameChanging(string value);
        partial void OnUsernameChanged();
        /// <summary>
        /// There are no comments for Property ModifiedNo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ModifiedNo
        {
            get
            {
                return this._ModifiedNo;
            }
            set
            {
                this.OnModifiedNoChanging(value);
                this._ModifiedNo = value;
                this.OnModifiedNoChanged();
                this.OnPropertyChanged("ModifiedNo");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ModifiedNo;
        partial void OnModifiedNoChanging(int value);
        partial void OnModifiedNoChanged();
        /// <summary>
        /// There are no comments for Property AddedNo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int AddedNo
        {
            get
            {
                return this._AddedNo;
            }
            set
            {
                this.OnAddedNoChanging(value);
                this._AddedNo = value;
                this.OnAddedNoChanged();
                this.OnPropertyChanged("AddedNo");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _AddedNo;
        partial void OnAddedNoChanging(int value);
        partial void OnAddedNoChanged();
        /// <summary>
        /// There are no comments for Property DeletedNo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int DeletedNo
        {
            get
            {
                return this._DeletedNo;
            }
            set
            {
                this.OnDeletedNoChanging(value);
                this._DeletedNo = value;
                this.OnDeletedNoChanged();
                this.OnPropertyChanged("DeletedNo");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _DeletedNo;
        partial void OnDeletedNoChanging(int value);
        partial void OnDeletedNoChanged();
        /// <summary>
        /// There are no comments for Property Date in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this.OnDateChanging(value);
                this._Date = value;
                this.OnDateChanged();
                this.OnPropertyChanged("Date");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
        /// <summary>
        /// There are no comments for Property Url in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this.OnUrlChanging(value);
                this._Url = value;
                this.OnUrlChanged();
                this.OnPropertyChanged("Url");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Url;
        partial void OnUrlChanging(string value);
        partial void OnUrlChanged();
        /// <summary>
        /// There are no comments for Property Message in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this.OnMessageChanging(value);
                this._Message = value;
                this.OnMessageChanged();
                this.OnPropertyChanged("Message");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Message;
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        /// <summary>
        /// There are no comments for WebHookPostCommits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<WebHookPostCommits> WebHookPostCommits
        {
            get
            {
                return this._WebHookPostCommits;
            }
            set
            {
                this._WebHookPostCommits = value;
                this.OnPropertyChanged("WebHookPostCommits");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<WebHookPostCommits> _WebHookPostCommits = new global::System.Data.Services.Client.DataServiceCollection<WebHookPostCommits>(null, global::System.Data.Services.Client.TrackingMode.None);
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NoduleDbModel.PostStatuses in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("PostStatuses")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class PostStatuses : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new PostStatuses object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="description">Initial value of Description.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static PostStatuses CreatePostStatuses(byte ID, string description)
        {
            PostStatuses postStatuses = new PostStatuses();
            postStatuses.Id = ID;
            postStatuses.Description = description;
            return postStatuses;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public byte Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private byte _Id;
        partial void OnIdChanging(byte value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Description in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnDescriptionChanging(value);
                this._Description = value;
                this.OnDescriptionChanged();
                this.OnPropertyChanged("Description");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Description;
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        /// <summary>
        /// There are no comments for WebHookPosts in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<WebHookPosts> WebHookPosts
        {
            get
            {
                return this._WebHookPosts;
            }
            set
            {
                this._WebHookPosts = value;
                this.OnPropertyChanged("WebHookPosts");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<WebHookPosts> _WebHookPosts = new global::System.Data.Services.Client.DataServiceCollection<WebHookPosts>(null, global::System.Data.Services.Client.TrackingMode.None);
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NoduleDbModel.WebHookPostCommits in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CommitId
    /// WebHookPostId
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("WebHookPostCommits")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CommitId", "WebHookPostId")]
    public partial class WebHookPostCommits : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new WebHookPostCommits object.
        /// </summary>
        /// <param name="webHookPostId">Initial value of WebHookPostId.</param>
        /// <param name="commitId">Initial value of CommitId.</param>
        /// <param name="order">Initial value of Order.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static WebHookPostCommits CreateWebHookPostCommits(long webHookPostId, string commitId, int order)
        {
            WebHookPostCommits webHookPostCommits = new WebHookPostCommits();
            webHookPostCommits.WebHookPostId = webHookPostId;
            webHookPostCommits.CommitId = commitId;
            webHookPostCommits.Order = order;
            return webHookPostCommits;
        }
        /// <summary>
        /// There are no comments for Property WebHookPostId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public long WebHookPostId
        {
            get
            {
                return this._WebHookPostId;
            }
            set
            {
                this.OnWebHookPostIdChanging(value);
                this._WebHookPostId = value;
                this.OnWebHookPostIdChanged();
                this.OnPropertyChanged("WebHookPostId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private long _WebHookPostId;
        partial void OnWebHookPostIdChanging(long value);
        partial void OnWebHookPostIdChanged();
        /// <summary>
        /// There are no comments for Property CommitId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CommitId
        {
            get
            {
                return this._CommitId;
            }
            set
            {
                this.OnCommitIdChanging(value);
                this._CommitId = value;
                this.OnCommitIdChanged();
                this.OnPropertyChanged("CommitId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CommitId;
        partial void OnCommitIdChanging(string value);
        partial void OnCommitIdChanged();
        /// <summary>
        /// There are no comments for Property Order in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Order
        {
            get
            {
                return this._Order;
            }
            set
            {
                this.OnOrderChanging(value);
                this._Order = value;
                this.OnOrderChanged();
                this.OnPropertyChanged("Order");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Order;
        partial void OnOrderChanging(int value);
        partial void OnOrderChanged();
        /// <summary>
        /// There are no comments for Commits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Commits Commits
        {
            get
            {
                return this._Commits;
            }
            set
            {
                this._Commits = value;
                this.OnPropertyChanged("Commits");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Commits _Commits;
        /// <summary>
        /// There are no comments for WebHookPosts in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public WebHookPosts WebHookPosts
        {
            get
            {
                return this._WebHookPosts;
            }
            set
            {
                this._WebHookPosts = value;
                this.OnPropertyChanged("WebHookPosts");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private WebHookPosts _WebHookPosts;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NoduleDbModel.WebHookPosts in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("WebHookPosts")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class WebHookPosts : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new WebHookPosts object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="date">Initial value of Date.</param>
        /// <param name="statusId">Initial value of StatusId.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static WebHookPosts CreateWebHookPosts(long ID, global::System.DateTime date, byte statusId)
        {
            WebHookPosts webHookPosts = new WebHookPosts();
            webHookPosts.Id = ID;
            webHookPosts.Date = date;
            webHookPosts.StatusId = statusId;
            return webHookPosts;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public long Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private long _Id;
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Date in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this.OnDateChanging(value);
                this._Date = value;
                this.OnDateChanged();
                this.OnPropertyChanged("Date");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
        /// <summary>
        /// There are no comments for Property PostData in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostData
        {
            get
            {
                return this._PostData;
            }
            set
            {
                this.OnPostDataChanging(value);
                this._PostData = value;
                this.OnPostDataChanged();
                this.OnPropertyChanged("PostData");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostData;
        partial void OnPostDataChanging(string value);
        partial void OnPostDataChanged();
        /// <summary>
        /// There are no comments for Property StatusId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public byte StatusId
        {
            get
            {
                return this._StatusId;
            }
            set
            {
                this.OnStatusIdChanging(value);
                this._StatusId = value;
                this.OnStatusIdChanged();
                this.OnPropertyChanged("StatusId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private byte _StatusId;
        partial void OnStatusIdChanging(byte value);
        partial void OnStatusIdChanged();
        /// <summary>
        /// There are no comments for Property RepoUrl in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string RepoUrl
        {
            get
            {
                return this._RepoUrl;
            }
            set
            {
                this.OnRepoUrlChanging(value);
                this._RepoUrl = value;
                this.OnRepoUrlChanged();
                this.OnPropertyChanged("RepoUrl");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _RepoUrl;
        partial void OnRepoUrlChanging(string value);
        partial void OnRepoUrlChanged();
        /// <summary>
        /// There are no comments for Property PullRequestReference in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PullRequestReference
        {
            get
            {
                return this._PullRequestReference;
            }
            set
            {
                this.OnPullRequestReferenceChanging(value);
                this._PullRequestReference = value;
                this.OnPullRequestReferenceChanged();
                this.OnPropertyChanged("PullRequestReference");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PullRequestReference;
        partial void OnPullRequestReferenceChanging(string value);
        partial void OnPullRequestReferenceChanged();
        /// <summary>
        /// There are no comments for Property Result in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                this.OnResultChanging(value);
                this._Result = value;
                this.OnResultChanged();
                this.OnPropertyChanged("Result");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Result;
        partial void OnResultChanging(string value);
        partial void OnResultChanged();
        /// <summary>
        /// There are no comments for Property Organization in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Organization
        {
            get
            {
                return this._Organization;
            }
            set
            {
                this.OnOrganizationChanging(value);
                this._Organization = value;
                this.OnOrganizationChanged();
                this.OnPropertyChanged("Organization");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Organization;
        partial void OnOrganizationChanging(string value);
        partial void OnOrganizationChanged();
        /// <summary>
        /// There are no comments for Property Repository in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Repository
        {
            get
            {
                return this._Repository;
            }
            set
            {
                this.OnRepositoryChanging(value);
                this._Repository = value;
                this.OnRepositoryChanged();
                this.OnPropertyChanged("Repository");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Repository;
        partial void OnRepositoryChanging(string value);
        partial void OnRepositoryChanged();
        /// <summary>
        /// There are no comments for PostStatuses in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public PostStatuses PostStatuses
        {
            get
            {
                return this._PostStatuses;
            }
            set
            {
                this._PostStatuses = value;
                this.OnPropertyChanged("PostStatuses");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private PostStatuses _PostStatuses;
        /// <summary>
        /// There are no comments for WebHookPostCommits in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<WebHookPostCommits> WebHookPostCommits
        {
            get
            {
                return this._WebHookPostCommits;
            }
            set
            {
                this._WebHookPostCommits = value;
                this.OnPropertyChanged("WebHookPostCommits");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<WebHookPostCommits> _WebHookPostCommits = new global::System.Data.Services.Client.DataServiceCollection<WebHookPostCommits>(null, global::System.Data.Services.Client.TrackingMode.None);
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}
