namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.Table
{
    class Table
    {
        public TableCell[,] Cells;

        public Table(int x, int y)
        {
            Cells = new TableCell[x,y];
        }
    }
}
