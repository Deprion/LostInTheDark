using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class Login : MonoBehaviour
{
    private static string _playFabId;
    private static string _sessionTicket;
    public static string PlayFabId { get { return _playFabId; } }
    public static string SessionTicket { get { return _sessionTicket; } }

    public GetPlayerCombinedInfoRequestParams InfoRequestParams;

    private void Awake()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
        {
            TitleId = PlayFabSettings.TitleId,
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = InfoRequestParams
        }, 
        (result) => 
        {
            _playFabId = result.PlayFabId;
            _sessionTicket = result.SessionTicket;
        }, 
        (error) => 
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }
}
