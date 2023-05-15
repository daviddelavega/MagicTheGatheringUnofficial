namespace MagicTheGathering.Cards
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * This interface is used to support Magic _Card Types that Tap.
     * It also Supports the Interface Seclusion principle
     */
    public interface Tappable
    {
        void Tap();

        void Untap();
    }
}
