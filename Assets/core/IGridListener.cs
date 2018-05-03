namespace Eblomino
{
    public interface IGridListener
    {
        void onCellCreated(Kreuz cell);

        void onSquareFound(Kreuz first, Kreuz second);
    }
}