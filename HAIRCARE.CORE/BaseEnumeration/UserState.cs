using Ardalis.SmartEnum;

namespace HAIRCARE.CORE.BaseEnumeration
{
    public abstract class UserState : SmartEnum<UserState>
    {
        /// <summary>
        /// User created but need verify email
        /// </summary>
        public static readonly UserState Temporary = new TemporaryUserState();

        /// <summary>
        /// User verified email,  not login yet, need login to reset password
        /// </summary>
        public static readonly UserState FirstLogin = new FirstLoginUserState();

        /// <summary>
        /// User verified email,  logged in and reset password
        /// </summary>
        public static readonly UserState Normal = new NormalUserState();

        /// <summary>
        /// Locked user state
        /// </summary>
        public static readonly UserState Locked = new LockedUserState();

        private UserState(string name, int value) : base(name, value)
        {
        }

        /// <summary>
        /// Display Name
        /// </summary>
        public abstract string DisplayName { get; }

        private sealed class TemporaryUserState : UserState
        {
            public TemporaryUserState() : base("TEMPORARY", 0) { }

            //TODO: Tung-Try to get display by culture
            public override string DisplayName => "TEMPORARY_USERSTATE_DISPLAY_NAME";
        }

        private sealed class FirstLoginUserState : UserState
        {
            public FirstLoginUserState() : base("FIRSTLOGIN", 1) { }

            public override string DisplayName => "FIRSTLOGIN_USERSTATE_DISPLAY_NAME";
        }

        private sealed class NormalUserState : UserState
        {
            public NormalUserState() : base("NORMAL", 1) { }

            public override string DisplayName => "NORMAL_USERSTATE_DISPLAY_NAME";
        }
        private sealed class LockedUserState : UserState
        {
            public LockedUserState() : base("LOCKED", 1) { }

            public override string DisplayName => "LOCKED_USERSTATE_DISPLAY_NAME";
        }
    }
}
