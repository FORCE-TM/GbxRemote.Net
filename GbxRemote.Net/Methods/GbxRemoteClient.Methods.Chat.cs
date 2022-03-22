using System.Collections.Generic;
using System.Threading.Tasks;
using GbxRemoteNet.XmlRpc;

namespace GbxRemoteNet
{
    /// <summary>
    /// Method Category: Chat
    /// </summary>
    public partial class GbxRemoteClient
    {
        /// <summary>
        /// Send a text message to all clients without the server login. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendServerMessageAsync(string message) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendServerMessage", message)
            );

        /// <summary>
        /// Send a localised text message to all clients without the server login, or optionally to a Login (which can be a single login or a list of comma-separated logins). The parameter is an array of structures {Lang='??', Text='...'}. If no matching language is found, the last text in the array is used. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendServerMessageToLanguageAsync(IEnumerable<Language> lang, string message) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendServerMessageToLanguage", lang, message)
            );

        /// <summary>
        /// Send a text message without the server login to the client with the specified PlayerId. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendServerMessageToIdAsync(string message, int loginId) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendServerMessageToId", message, loginId)
            );

        /// <summary>
        /// Send a text message without the server login to the client with the specified login. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendServerMessageToLoginAsync(string message, string playerLogins) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendServerMessageToLogin", message, playerLogins)
            );

        /// <summary>
        /// Send a text message to all clients. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendAsync(string message) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSend", message)
            );

        /// <summary>
        /// Send a localised text message to all clients, or optionally to a Login (which can be a single login or a list of comma-separated logins). The parameter is an array of structures {Lang='??', Text='...'}. If no matching language is found, the last text in the array is used. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendToLanguageAsync(IEnumerable<Language> lang, string message) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendToLanguage", lang, message)
            );

        /// <summary>
        /// Send a text message to the client with the specified login. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendToLoginAsync(string message, string playerLogins) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendToLogin", message, playerLogins)
            );

        /// <summary>
        /// Send a text message to the client with the specified PlayerId. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatSendToIdAsync(string message, int playerId) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatSendToId", message, playerId)
            );

        /// <summary>
        /// Returns the last chat lines. Maximum of 40 lines. Only available to Admin.
        /// </summary>
        public async Task<string[]> GetChatLinesAsync() =>
            (string[])XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetChatLines")
            );

        /// <summary>
        /// The chat messages are no longer dispatched to the players, they only go to the rpc callback and the controller has to manually forward them. The second (optional) parameter allows all messages from the server to be automatically forwarded. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatEnableManualRoutingAsync(bool enable, bool forward) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatEnableManualRouting", enable, forward)
            );

        /// <summary>
        /// (Text, SenderLogin, DestLogin) Send a text message to the specified DestLogin (or everybody if empty) on behalf of SenderLogin. DestLogin can be a single login or a list of comma-separated logins. Only available if manual routing is enabled. Only available to Admin.
        /// </summary>
        public async Task<bool> ChatForwardToLoginAsync(string text, string senderLogin, string destinationLogin) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChatForwardToLogin", text, senderLogin, destinationLogin)
            );

        /// <summary>
        /// Set a new chat time value in milliseconds (actually 'chat time' is the duration of the end race podium, 0 means no podium displayed.). Only available to Admin.
        /// </summary>
        public async Task<bool> SetChatTimeAsync(int chatTime) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetChatTime", chatTime)
            );

        /// <summary>
        /// Get the current and next chat time. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetChatTimeAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetChatTime")
            );
    }
}
