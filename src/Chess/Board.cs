using Chess.Pieces;

namespace Chess;
public class Board
{
    private Piece?[,] _field;
    public Piece?[,] Field 
    {
        get => (Piece?[,])_field.Clone();
    }

    public readonly int size;

    public Board(int size = 8)
    {
        if (size < 1)
            throw new ArgumentOutOfRangeException(nameof(size));

        this.size = size;

        _field = new Piece[size, size];
    }

    public Piece? HasPiece(Coords coords)
        => _field[coords.x, coords.y] ?? null;

    public void PlacePiece(Piece piece)
    {
        if (_field[piece.Position.x, piece.Position.y] is not null)
            throw new Exception($"Piece on position ({piece.Position.x}, {piece.Position.y} already placed.)");

        _field[piece.Position.x, piece.Position.y] = piece;
    }
}
