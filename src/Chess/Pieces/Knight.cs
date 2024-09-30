namespace Chess.Pieces;
public class Knight : Piece
{
    private List<(int x, int y)> _offsets = new()
    {
        (-1, -2), (1, -2), (-2, -1), (-2, 1), (-1, 2), (1, 2), (2, -1), (2, 1)
    };

    public Knight(Coords position, Board board) : base(position, board)
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
