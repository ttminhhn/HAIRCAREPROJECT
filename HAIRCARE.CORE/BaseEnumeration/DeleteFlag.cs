using Ardalis.SmartEnum;

namespace HAIRCARE.CORE.BaseEnumeration
{
    public abstract class DeleteFlag : SmartEnum<DeleteFlag>
    {
        /// <summary>
        /// Deleted Record
        /// </summary>
        public static readonly DeleteFlag Deleted = new RecordDeletedFlag();

        /// <summary>
        /// Available Record
        /// </summary>
        public static readonly DeleteFlag Available = new RecordAvailableFlag();
        private DeleteFlag(string name, int value) : base(name, value)
        {
        }

        /// <summary>
        /// Display Name
        /// </summary>
        public abstract string DisplayName { get; }

        private sealed class RecordDeletedFlag : DeleteFlag
        {
            public RecordDeletedFlag() : base("DELETED", 1) { }

            //TODO: Tung-Try to get display by culture
            public override string DisplayName => "RECORD_DELETED_DISPLAY_NAME";
        }

        private sealed class RecordAvailableFlag : DeleteFlag
        {
            public RecordAvailableFlag() : base("AVAILABLE", 0) { }

            public override string DisplayName => "RECORD_AVAILABLE_DISPLAY_NAME";
        }
    }
}
