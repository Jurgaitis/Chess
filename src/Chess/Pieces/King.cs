namespace Chess.Pieces;
public class King : Piece
{
    private List<(int x, int y)> _offsets = new()
    {
        (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1)
    };

    public King(Coords position, Board board) : base(position, board)
    {
    }

    public override List<Piece> PiecesUnderThreat()
    {
        List<Piece> pieces = new();

        foreach (var offset in _offsets)
        {
            var piece = CrossPiece(offset.x, offset.y);
            if (piece is not null)
            {
                pieces.Add(piece);
                break;
            }
        }
        return pieces;
    }
}
