using System.Runtime.Serialization;

namespace MietHack_10_2023.Database.BaseTypes
{
    public enum Status
    {
        /// <summary>
        /// Администратор
        /// </summary>
        [EnumMember(Value = "Администратор")]
        Admin = 0,

        /// <summary>
        /// Руководитель
        /// </summary>
        [EnumMember(Value = "Руководитель")] 
        Manager = 1,

        /// <summary>
        /// Участник
        /// </summary>
        [EnumMember(Value = "Участник")]
        Participant = 1
    }
}
