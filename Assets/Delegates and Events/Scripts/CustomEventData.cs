/*Adapted from: 
 *  https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#5cf5960fedbc2a281acd21fa
 *  https://medium.com/geekculture/how-to-use-events-to-implement-a-messaging-system-in-unity-c-342ab4806d53 
 */

using UnityEngine.Events;

namespace Delegates_and_Events.Scripts
{

    #region Main Class

    [System.Serializable]
    public class CustomEvent : UnityEvent<CustomEventData> { }

    #endregion

    #region Custom Enum

    public enum CustomEventTriggers
    {
        ChildAvatarUpdateOffline,
        ChildSessionDataOffline,
        ChangeAvatarClothing,
        UserLoggedInTeacher,
        UserRegisteredChild,
        ChildSessionDataGet,
        UserLoggedInParent,
        SaveSessionOffline,
        ChildAvatarUpdate,
        RegisteredParent,
        UserUpdatedChild,
        EditChildDetails,
        StickerUnlocked,
        OnPhotoUploaded,
        OnPictureTaken,
        UserLoggedOut,
        GameDataGet,
        SaveSession,
        OnApiError
    }

    #endregion

    #region Custom Container

    /// <summary>
    /// 
    /// </summary>
    public class CustomEventData
    {
        #region Variables

        public int eventDataInteger;
        public string eventDataString;
        public float eventDataFloatingPoint;

        #endregion

        #region Properties



        #endregion

        #region Unity Event Functions



        #endregion

        #region Member Functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public CustomEventData(int eventData)
        {
            eventDataInteger = eventData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public CustomEventData(string eventData)
        {
            eventDataString = eventData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public CustomEventData(float eventData)
        {
            eventDataFloatingPoint = eventData;
        }

        #endregion
    }

    #endregion

}