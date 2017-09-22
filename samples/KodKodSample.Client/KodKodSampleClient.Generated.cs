﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.7.2.0 (NJsonSchema v9.6.3.0) (http://NSwag.org)
// </auto-generated>
//----------------------

namespace KodKodSample.Client
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.7.2.0")]
    public partial class KodKodSampleClient 
    {
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
        private string _baseUrl = "";
        
        public KodKodSampleClient(string baseUrl)
        {
            BaseUrl = baseUrl; 
    		_settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() => 
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
    	}
    
        public string BaseUrl 
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
    
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Pet> PutPetAsync(Pet pet)
        {
            return PutPetAsync(pet, System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Pet> PutPetAsync(Pet pet, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/pet");
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(pet, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Pet); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Pet>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
    
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }
    
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
            
                        return default(Pet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Pet> PetFindByStatusAsync(Status status)
        {
            return PetFindByStatusAsync(status, System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Pet> PetFindByStatusAsync(Status status, System.Threading.CancellationToken cancellationToken)
        {
            if (status == null)
                throw new System.ArgumentNullException("status");
    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/pet/findByStatus?");
            urlBuilder_.Append("status=").Append(System.Uri.EscapeDataString(System.Convert.ToString(status, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Pet); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Pet>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
    
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }
    
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
            
                        return default(Pet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Pet> PetFindByTagsAsync(System.Collections.Generic.IEnumerable<object> tags)
        {
            return PetFindByTagsAsync(tags, System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Pet> PetFindByTagsAsync(System.Collections.Generic.IEnumerable<object> tags, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/pet/findByTags?");
            if (tags != null) foreach (var item_ in tags) { urlBuilder_.Append("tags=").Append(System.Uri.EscapeDataString(System.Convert.ToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
            urlBuilder_.Length--;
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(Pet); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<Pet>(responseData_, _settings.Value);
                                return result_; 
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                        }
                        else
                        if (status_ == "400") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
    
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }
    
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
            
                        return default(Pet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
        /// <returns>Error</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ProblemDetails> GetPetAsync(int id)
        {
            return GetPetAsync(id, System.Threading.CancellationToken.None);
        }
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Error</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ProblemDetails> GetPetAsync(int id, System.Threading.CancellationToken cancellationToken)
        {
            if (id == null)
                throw new System.ArgumentNullException("id");
    
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/pet/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(System.Convert.ToString(id, System.Globalization.CultureInfo.InvariantCulture)));
    
            var client_ = new System.Net.Http.HttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/problem+json"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "400") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
                        else
                        if (status_ == "404") 
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
                            } 
                            catch (System.Exception exception) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception);
                            }
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
                        else
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            var result_ = default(ProblemDetails); 
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseData_, _settings.Value);
    
                            } 
                            catch (System.Exception exception_) 
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception_);
                            }
    
                            throw new SwaggerException<ProblemDetails>("Error", status_, responseData_, headers_, result_, null);
                        }
            
                        return default(ProblemDetails);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }
    
    }
    
    

    /// <summary>A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class ProblemDetails : System.ComponentModel.INotifyPropertyChanged
    {
        private string _type;
        private string _title;
        private int? _status;
        private string _detail;
        private string _instance;
    
        /// <summary>A URI reference [RFC3986] that identifies the problem type. This specification encourages that, when
        /// dereferenced, it provide human-readable documentation for the problem type
        /// (e.g., using HTML [W3C.REC-html5-20141028]).  When this member is not present, its value is assumed to be
        /// "about:blank".</summary>
        [Newtonsoft.Json.JsonProperty("Type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type
        {
            get { return _type; }
            set 
            {
                if (_type != value)
                {
                    _type = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        /// <summary>A short, human-readable summary of the problem type.It SHOULD NOT change from occurrence to occurrence
        /// of the problem, except for purposes of localization(e.g., using proactive content negotiation;
        /// see[RFC7231], Section 3.4).</summary>
        [Newtonsoft.Json.JsonProperty("Title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title
        {
            get { return _title; }
            set 
            {
                if (_title != value)
                {
                    _title = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        /// <summary>The HTTP status code([RFC7231], Section 6) generated by the origin server for this occurrence of the problem.</summary>
        [Newtonsoft.Json.JsonProperty("Status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Status
        {
            get { return _status; }
            set 
            {
                if (_status != value)
                {
                    _status = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        /// <summary>A human-readable explanation specific to this occurrence of the problem.</summary>
        [Newtonsoft.Json.JsonProperty("Detail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Detail
        {
            get { return _detail; }
            set 
            {
                if (_detail != value)
                {
                    _detail = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        /// <summary>A URI reference that identifies the specific occurrence of the problem.It may or may not yield further information if dereferenced.</summary>
        [Newtonsoft.Json.JsonProperty("Instance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Instance
        {
            get { return _instance; }
            set 
            {
                if (_instance != value)
                {
                    _instance = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static ProblemDetails FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(data);
        }
    
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class Pet : System.ComponentModel.INotifyPropertyChanged
    {
        private long? _id;
        private Category _category;
        private string _name;
        private System.Collections.ObjectModel.ObservableCollection<string> _photoUrls;
        private System.Collections.ObjectModel.ObservableCollection<Tag> _tags;
        private Status? _status;
    
        [Newtonsoft.Json.JsonProperty("Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? Id
        {
            get { return _id; }
            set 
            {
                if (_id != value)
                {
                    _id = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Category Category
        {
            get { return _category; }
            set 
            {
                if (_category != value)
                {
                    _category = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name
        {
            get { return _name; }
            set 
            {
                if (_name != value)
                {
                    _name = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("PhotoUrls", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.ObjectModel.ObservableCollection<string> PhotoUrls
        {
            get { return _photoUrls; }
            set 
            {
                if (_photoUrls != value)
                {
                    _photoUrls = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Tags", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.ObjectModel.ObservableCollection<Tag> Tags
        {
            get { return _tags; }
            set 
            {
                if (_tags != value)
                {
                    _tags = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Status? Status
        {
            get { return _status; }
            set 
            {
                if (_status != value)
                {
                    _status = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Pet FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Pet>(data);
        }
    
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class Category : System.ComponentModel.INotifyPropertyChanged
    {
        private long? _id;
        private string _name;
    
        [Newtonsoft.Json.JsonProperty("Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? Id
        {
            get { return _id; }
            set 
            {
                if (_id != value)
                {
                    _id = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name
        {
            get { return _name; }
            set 
            {
                if (_name != value)
                {
                    _name = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Category FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Category>(data);
        }
    
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class Tag : System.ComponentModel.INotifyPropertyChanged
    {
        private long? _id;
        private string _name;
    
        [Newtonsoft.Json.JsonProperty("Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? Id
        {
            get { return _id; }
            set 
            {
                if (_id != value)
                {
                    _id = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name
        {
            get { return _name; }
            set 
            {
                if (_name != value)
                {
                    _name = value; 
                    RaisePropertyChanged();
                }
            }
        }
    
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static Tag FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Tag>(data);
        }
    
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public enum Status
    {
        Available = 0,
    
        Pending = 1,
    
        Sold = 2,
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.7.2.0")]
    public class SwaggerException : System.Exception
    {
        public string StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException) 
            : base(message, innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.7.2.0")]
    public class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException) 
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}