namespace Chess.Pieces;
public class Bishop : Piece
{
    private List<(int x, int y)> _offsets = new()
    {
        (-1, 1), (-1, -1), (1, 1), (1, -1)
    };

    public Bishop(Coords position, Board board) : base(position, board)
    {
    }

    public override List<Piece> PiecesUnderThreat()
    {
        List<Piece> pieces = new();

        foreach (var offset in _offsets)
        {
            for (int i = 0; i < Field.size; i++)
            {
                var piece = CrossPiece(offset.x * (i + 1), offset.y * (i + 1));
                if (piece is not null)
                {
                    pieces.Add(piece);
                    break;
                }
            }
        }
        return pieces;
    }
}
