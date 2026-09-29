//Pedro Elias dos Santos Vincensi
using System.Text;
internal class Program

{
    //Variaveis para poderem ser ascessadas por qualquer método.

    string playerName;
        
        sbyte playerHealth;
        sbyte playerStamina;
        sbyte playerMagicSpace;
        sbyte playerDodge;
        sbyte playerBaseDamage;

        sbyte boss1Health;
        sbyte boss1Damage;
        sbyte boss1Stamina;
        sbyte bossBaseDamage;

        byte boss1DTAtaque;
        byte boss1DTEsquiva;
    public Program()
    {
        Menu();
        Game();
    
    }


    public void Menu()
    {
        Console.WriteLine("\nOlá! Seja bem vindo ao mundo de Terreteia! Aqui você encontrará aventuras incríveis e desafios emocionantes. Prepare-se para explorar terras misteriosas, enfrentar criaturas lendárias e descobrir segredos antigos. Boa sorte em sua jornada!\n");
        Console.WriteLine("Digite seu nome para começar a aventura:");

        string playerName = Console.ReadLine() ?? "Aventureiro";
        Console.Clear();

        byte playerClass = 0;

        Console.WriteLine($"Bem-vindo, {playerName}! Sua jornada começa agora. Prepare-se para enfrentar desafios e tomar decisões que moldarão seu destino em Terreteia.\n");
        Console.ReadKey();
        Console.WriteLine("Para ser admitido na nossa guilga de aventureios, precisamos que você enfrente o seu primeiro chefe!\n");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Mas antes, nós diga um pouco mais sobre você!: \n\n");
        Console.WriteLine("(1) Eu sou forte, sempre acreditei nós meus braços e na minha força física, sou como uma muralha!\n(+2 Em testes de dano // 22 de Vida // 5 Stamina)\nHabilidade Especial: Contra Ataque - Ao receber dano de um ataque, você gastar Stamina para dar um ataque garantido ao seu oponente\n\n");

        Console.WriteLine("(2) Eu sou ágil, sempre acreditei na minha velocidade e na minha capacidade de esquiva, sou como um raio!\n(+3 Em testes de Esquiva // 18 de Vida // 8 Stamina)\n Habilidade Especial: Velocidade SobreHumana - Caso erre um ataque, você pode gastar 1 Stamina para esquiva do proximo ataque do chefe.\n\n");

        Console.WriteLine("(3) Eu smepre me interessei pelas artes arcanas, sempre acreditei na minha inteligência e na minha capacidade de manipular o mundo ao meu redor, sou como um mago!\n(3 Espaçoes de Magia // 15 de Vida // 10 Stamina)\n Habilidade Especial: Magia Arcana - Você pode gastar 1 Stamina para lançar um feitiço de lentidão no inimigo para diminuir sua DT de ataquem em 4 pontos\n\n");  
        Console.WriteLine("OBS: Cada carga de stamina permite que você adicione +5 em um teste, ou use uma habilidade.\n\n");

        Console.WriteLine("Escolha uma das opções acima digitando o número correspondente (1, 2 ou 3):");
        byte.TryParse(Console.ReadLine(), out playerClass);

        if (playerClass < 1 || playerClass > 3)
        {
            Console.WriteLine("Wow! Parece que você não gosta de se encaixar no padrão, então você sera um aventureiro neutro, sem especialidade definida. Boa sorte na sua jornada!\n\n");
        }
        Console.Clear();

        //Atributos do jogador
        playerHealth = 0;
        playerStamina = 0; 
        playerMagicSpace = 0;
        playerDodge = 0;
        playerBaseDamage = 3;

        if (playerClass == 1)
        {
            playerHealth = 22;
            playerStamina = 3;
            playerDodge = 0;
            playerMagicSpace = 0;
            playerBaseDamage = 5;
        }
        else if (playerClass == 2)
        {
            playerHealth = 18;
            playerStamina = 8;
            playerDodge = 3;
            playerMagicSpace = 0;
            playerBaseDamage = 3;
        }
        else if (playerClass == 3)
        {
            playerHealth = 15;
            playerStamina = 10;
            playerDodge = 0;
            playerMagicSpace = 3;
            playerBaseDamage = 2;
        }
        else
        {
            playerHealth = 20;
            playerStamina = 5; 
            playerDodge = 1;  
            playerMagicSpace = 0;
            playerBaseDamage = 2;
        }

        // Atributos do chefe
        boss1Health = 30;
        boss1Damage = 4;
        boss1Stamina = 5;
        bossBaseDamage = 3;
        boss1DTAtaque = 13; //Numero que o jogador precisa obter no randy para efetuar um ataque bem sucedido no chefe
        boss1DTEsquiva = 15; //Numero que o jogador precisa obter no randy para efetuar uma esquiva bem sucedida no chefe

    }

    public void Game()

    {
        // Jogo em si



        Console.WriteLine($" {playerName}, Você concente com sua cabeça em um movimento sutíl, um grande papel aparece a sua frente, material escuro, quente, brasa ainda quente emanando direto dela, e com um movimento sutil, você toca no espaço vazio no papel, seu sangue voa formando sua assinatura, e com isso, você desmaia. \n\n");

        Console.ReadKey();
        Console.Clear();

        Console.WriteLine($"A sua frente, você vê uma fora bestial, parece com um lobo, mas invertido, suas costas são sua barriga, com as costelas expostas, e sua boca é enorme, com dentes afiados, e seus olhos são vermelhos, e ele parece estar faminto. \n\n");

        Console.ReadKey();
        Console.Clear();



        Console.WriteLine($"Sua vida: {playerHealth} | Sua Stamina: {playerStamina} | Sua Esquiva: {playerDodge} | Espaços de Magia: {playerMagicSpace}\n\n");

        Console.ReadKey();
        Console.Clear();

        byte playerTesteAtaque = 0;
        byte playerTesteEsquiva = 0;
        Random rnd = new Random();
        byte playerAction = 0;



        while (playerHealth > 0 && boss1Health > 0)
        {
            byte dmgBoss;
            byte dmgPlayer;

            Console.WriteLine($"O que você faz, {playerName}?\n\n(1) Atacar o chefe com sua arma.\n(2) Desviar.\n(3) Usar uma magia (se você tiver).\n(4) Preparar seu próximo ataque\n(5) Fugir do chefe(desonra)\n(6) Usar Habilidade Especial\n(7) Preparar esquiva ou ataque\n(8) Ver status personagem\n\n");

            byte.TryParse(Console.ReadLine(), out playerAction);

            if (playerAction < 1 || playerAction > 8 )
            {
                Console.WriteLine("Opção inválida! Por favor, escolha uma ação válida.\n");
                continue;
            }
            else if (playerAction == 1)
            {
                //Lógica randy para testes de ataque
                
                playerTesteAtaque = (byte)rnd.Next(1,20); //Gera um número aleatório entre 1 e 20 para o teste de ataque

                switch(playerTesteAtaque) {
                
                case 1:
                    Console.WriteLine("Você errou miseravelmente o ataque! O chefe aproveita a abertura e te da um ataque em cheio!\n");
                    
                    playerHealth -= boss1Damage;
                    break;


            }
            }

        }

        //variavel temp
        //
    }

    private static void Main(string[] args)
    {
        _ = new Program();
    }

}