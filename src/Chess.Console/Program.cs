using System.Text;

using Chess;
using Chess.Pieces;

string inputFilePath = @"..\..\..\data.txt";

Dictionary<string, char> piecesChars = new()
{
    { "King", '♔' },
    { "Queen", '♕' },
    { "Rook", '♖' },
    { "Bishop", '♗' },
    { "Knight", '♘' },
    { "Shadow", '?' }
};

Console.OutputEncoding = Encoding.Unicode;

Board board = new();

var pieces = GetInputData(inputFilePath);

foreach (var piece in pieces)
{
    try
    {
        board.PlacePiece(piece);
    }
    catch { }
}

DrawBoard();

foreach (var piece in pieces)
{
    piece.PiecesUnderThreat().ForEach(threatenPiece =>
    {
        Console.WriteLine($"{piece.ToString()} threatens " + threatenPiece.ToString());
    });
}

List<Piece> GetInputData(string filePath)
{
    List<Piece> pieces = new();
    var FileStream = File.OpenRead(filePath);
    StreamReader reader = new(FileStream);
    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(' ');
        try
        {
            Coords position = new(Int32.Parse(data[1]), Int32.Parse(data[2]));
            switch (data[0])
            {
                case "king":
                    pieces.Add(new King(position, board));
                    break;
                case "queen":
                    pieces.Add(new Queen(position, board));
                    break;
                case "rook":
                    pieces.Add(new Rook(position, board));
                    break;
                case "bishop":
                    pieces.Add(new Bishop(position, board));
                    break;
                case "knight":
                    pieces.Add(new Knight(position, board));
                    break;
                case "shadow":
                    pieces.Add(new Shadow(position, board));
                    break;
            }
        }
        catch {}
    }
    return pieces;
}

void DrawBoard()
{
    Console.Write("{0, 2}", " ");
    for (int i = 0; i < board.size; i++)
    {
        Console.Write("{0, 2}", i);
    }
    Console.WriteLine();
    for (int y = 0; y < board.size; y++)
    {
        Console.Write("{0, 2}", y);
        for (int x = 0; x < board.size; x++)
        {
            if (board.Field[x, y] is null)
                Console.Write("{0, 2}", '·');
            else
                Console.Write("{0, 2}", piecesChars[board.Field[x, y].GetType().Name]);
        }
        Console.WriteLine();
    }
}