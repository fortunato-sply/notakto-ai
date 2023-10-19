public class Notakto
{
    int boards = 0;
    bool[] data;
    byte[] sums;
    int lastBoard = 0;
    int lastPosition = 0;

    public Notakto(int boards)
    {
        this.boards = boards;
        data = new bool[9 * boards];
        sums = new byte[8 * boards];
    }
    
    /// <summary>
    /// Obtém a última jogada
    /// </summary>
    public (int board, int position) GetLast()
        => (lastBoard, lastPosition);

    /// <summary>
    /// Joga em uma posição em um tabuleiro
    /// </summary>
    public void Play(int board, int pos)
    {
        data[9 * board + pos] = true;

        int sumInitialPos = board * 8;

        //vertical
        sums[sumInitialPos + pos % 3] += 1;
        //horizontal
        sums[sumInitialPos + 3 + pos / 3] += 1;

        //diagonal
        if(pos % 4 == 0)
            sums[sumInitialPos + 6] += 1;

        if(pos % 2 == 0 && pos % 8 != 0)
            sums[sumInitialPos + 7] += 1;
    }
    
    /// <summary>
    /// Testa e retorna verdadeiro se você pode jogar em um tabuleiro
    /// </summary>
    public bool CanPlay(int board)
    {
        int boardInData = board * 8;
        for(int i = boardInData; i < boardInData + 8; i++)
        {
            if(sums[i] >= 3)
                return false;
        }

        return true;
    }
    
    /// <summary>
    /// Retorna verdadeiro se o jogo acabou
    /// </summary>
    public bool GameEnded()
    {
        for(int i = 0; i < boards; i++)
        {
            if(CanPlay(i))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Cria uma cópia indentica do estado.
    /// </summary>
    public Notakto Clone()
    {
        Notakto copy = new Notakto(boards);
        Array.Copy(
            this.data, 
            copy.data, 
            this.data.Length
        );
        Array.Copy(
            this.sums, 
            copy.sums, 
            this.sums.Length
        );
        return copy;
    }

    /// <summary>
    /// Obtém próximas jogadas válidas
    /// </summary>
    public IEnumerable<Notakto> Next()
    {
        List<Notakto> validMove = new();

        
    }
}