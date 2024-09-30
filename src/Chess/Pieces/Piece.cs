namespace Chess.Pieces;
public abstract class Piece
{
    public Board Field { get; }
    public Coords Position { get; set; }

    public Piece(Coords position, Board board)
    {
        if (position.x < 0 || position.x >= board.size || position.y < 0 || position.x >= board.size)
            throw new ArgumentOutOfRangeException(nameof(position));

        Position = position;
        Field = board;
    }

    public abstract List<Piece> PiecesUnderThreat();

    protected Piece? CrossPiece(int offsetX, int offsetY)
    {
        Coords position = new(Position.x + offsetX, Position.y + offsetY);

        if (position.x < 0 || position.y < 0 || position.x >= Field.size || position.y >= Field.size)
            return null;

        return Field.HasPiece(position);
    }

    public override string ToString()
    {
        return $"{GetType().Name}: ({Position.x}, {Position.y})";
    }
}
