using System.Runtime.Serialization;

namespace MietHack_10_2023.Database.BaseTypes
{
    public enum Status
    {
        /// <summary>
        /// Администратор
        /// </summary>
        [EnumMember(Value = "Администратор")]
        Admin,

        /// <summary>
        /// Руководитель
        /// </summary>
        [EnumMember(Value = "Руководитель")] 
        Manager,

        /// <summary>
        /// Участник
        /// </summary>
        [EnumMember(Value = "Участник")]
        Participant
    }
}
