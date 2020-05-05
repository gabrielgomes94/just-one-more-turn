# Só mais um turno: Game Design Document

## 1. Introdução

Só mais um turno é um jogo de estratégia inspirado na franquia Civilization.

Cada jogador inicia com uma civilização no ano 4000 AC, logo após a descoberta da Agricultura.
Assim, cada jogador deve guiar seu povo pela história, tentando resistir ao teste do tempo, enquanto enfrentam outros adversários em batalhas militares, econômicas ou diplomáticas na tentativa de ganhar o jogo.

Cada jogador pode construir cidades, melhorar terrenos, treinar unidades civis e militares, conquistar cidades ou colonizar novas terras.

## 2. Visão Geral do Jogo

Cada jogador inicia o jogo com um soldado de nível 1(um Guerreiro) e um colono.
Com o colono ele pode fundar uma cidade.
Com o soldado ele pode explorar o território, se proteger e atacar outros.

Ao fundar sua primeira cidade, o jogador inicia o seu império.
Então, ele deve buscar expandi-lo: construir novas cidades, distritos e construções, melhorar o terreno ao redor da cidade, extrair recursos, treinar novos cidadãos para trabalhar no império e pesquisar novas tecnologias e cívicos pra avançar sua sociedade no tempo.

Além disso, o jogador deve manter a fé da população estável para evitar a insatisfação da população.
Pois uma população insatisfeita é menos produtiva.
E uma população muito insatisfeita pode causar revoltas.

O mapa é gerado automaticamente no começo do jogo.
Então o jogador e seus adversários devem disputar os espaços do mapa: construir cidades, melhorias, se expandirem, se movimentarem e batalharem por melhores espaços.

Desde o início do jogo, a ideia é incentivar o jogador a definir e implementar suas estratégias com base nas condições ambientais: wide x tall, sparse x dense, quais especializações escolher pras cidades a serem fundadas, quais tipo de unidade construir, como alocar os slots e por aí vai.

## 3. Mecânicas do Jogo

- 3.1. Cidades
- 3.2. Recursos
- 3.3. Unidades
- 3.4. Fé
- 3.5. Revoltas
- 3.6. Combate

### 3.1 Cidades

Um império é composto por cidades.

Cada cidade deve ser construída por uma unidade de colono.
Colonos são produzidos em cidades e consomem um slot de cidadão.

Ao ser criado, um colono deve ser levado até o ponto do mapa onde o jogador quer construir uma cidade.
- Ações de um colono: fundar cidade, se movimentar, dormir/esperar

#### Fronteiras da cidade
Uma vez que a cidade é criada, ela possui um raio de atuação.
Esse raio de atuação equivale ao território dentro dos limites da cidade.
Esse território vai crescendo com o passar do tempo: o crescimento populacional, somados à produção de cultura e fé , delimitam as fronteiras de uma cidade.

Tropas militares também podem reivindicar certos pedaços de terra, a partir de algum momento do jogo.
Se uma tropa militar reivindica um terreno que pertence à outro jogador, isso pode gerar conflitos militares.

#### Recursos

Uma cidade pode extrair os recursos ao seu redor e tem alguns itens de rendimento:

- Alimento
- Ouro
- Produção
- Ciência
- Cultura
- Fé

##### Alimento

Alimentos são necessários pra alimentar toda sua população.
Uma cidade com excesso de produção de alimentos vai conseguir crescer.

E cada vez que uma cidade crescer, ela vai ganhar um novo espaço de cidadão.

Uma cidade consegue produzir alimentos ao fazer e trabalhar em fazendas, pastos e barcos de pesca.

##### Ouro

Ouro é necessário para: comprar construções, comprar tropas, contratar tropas de cidade-estado, negociar com outras civilizações, dentre outras possibilidades.

Uma cidade consegue produzir ouro ao trabalhar recursos que geram ouro ou a construir distritos comerciais e/ou portos. Além disso, uma cidade pode fazer um entreposto comercial para lucrar com rotas comerciais que passam por suas estradas.

##### Produção

Produção é necessária para: construir construções e tropas.

Uma cidade consegue produção ao fazer minas, serrarias e distritos industriais.

##### Ciência

Ciência é necessária para fazer o jogador progredir nas tecnologias do jogo.

Cada avanço tecnológico libera novas tropas, distritos ou construções.

##### Cultura

Cultura é necessária para fazer o jogador progredir nos cívicos do jogo.

Cada avanço cívico libera novas políticas para o jogador implementar.
Cada política tem um impacto passivo no jogo

#### Fé

Fé é necessária para manter os cidadãos **acreditando** no seu império.
Se os cidadãos de uma determinada cidade não acreditarem no império, eles vão querer se revoltar ou vão querer se anexar a outro império.

Basicamente, a Fé está diretamente relacionada à felicidade das pessoas em relação à civilização.
Além disso, a fé também serve pra produzir uma religião.

Fundar uma religião dá alguns bônus para o jogador.

Uma cidade consegue produzir fé se: estiver próxima a alguma maravilha da natureza ou se possuir distritos religiosos, com construções como templos e monastérios.

Posteriormente, conforme o jogo for progredindo, o jogador terá a opção de selecionar políticas que geram ou consomem mais fé.

#### Construções, distritos, maravilhas e melhorias

Construções: edificações, melhorias de terreno, distritos e maravilhas
Dentro das fronteiras de uma cidade, o jogador pode construir: edificações, distritos, maravilhas do mundo e melhorias de terreno.

Cada um desses itens possui custos:
    - Custo de produção:
        - total de `produção` necessária pra fazer tal item
        - total de `ouro` necessário pra comprar
    - Custo de manutenção: custo em `ouro` por turno de cada construção

- Construções: são prédios feitos no centro da cidade ou em algum distrido com alguma finalidade.
Exemplos:
    - construir um banco dentro de um distrito comercial, com o objetivo de aumentar a produção de ouro na cidade.
    - construir uma muralha em 9 tiles ao redor da cidade

- Distritos: são terrenos delimitados para certos tipos de construção.
Exemplo:
    - um distrito comercial permite à cidade fazer mais rotas comerciais e produzir mais ouro.

- Maravilhas: construções especiais que dão bônus ao jogador que construir.
Exemplo:
    - Pirâmides do Egito
    - Torre Eifel
    - Grande Biblioteca

- Melhorias de terreno: são construções que o jogador faz em um terreno pra trabalhar certos recursos.
Exemplos:
    - construir uma fazenda numa planície pra conseguir alimentos.
    - construir uma mina numa coluna pra aumentar a produção.
    - fazer uma platation num campo de Açúcar pra conseguir alimentos e ouro.
    - fazer um forte numa colina pra proteger a cidade

##### Lista de Construções

A lista de construções precisa ser elaborada ainda.

Mas cada distrito base pode seguir esse template:
- nível 1 - idade antiga
- nível 2 - idade média
- nível 3 - renascença
- nível 4 - industrial
- nível 5 - moderno

E aí espalhar algumas construções como palácio, monumento e muralhas no centro da cidade.

##### Lista de Distritos

Distritos servem pra especializar uma cidade.
Cada distrito construído vai ditar o poder de uma cidade conforme o jogo for progredindo.
Uma cidade focada em comércio provavelmente vai ter vários distritos de comércio e talvez um de porto.
Já uma cidade focada em produção científica vai ter distritos científicos e  melhorias focadas em potencializar essa produção.

Todos os distritos se relacionam entre si.
Um distrito industrial, ao lado de um distrito comercial, vai fornecer bônus de produção ao seu vizinho. E vice-versa.

Existem 5 distritos de base e 3 distritos auxiliares.

###### Distritos base

- Comercial: Responsável por produzir ouro
- Científico: Responsável por produzir ciência
- Cultural: Responsável por produzir cultura
- Indutrial: Responsável por gerar produção
- Religioso: Responsável por gerar fé.

###### Distritos secundários

- Base Militar
    - Bônus pra produção de tropas, defesa, bonus pro upgrade de tropas
- Porto
    - Bônus pra produção de navios
    - Bônus de ouro e alimentos
    - Entreposto comercial
- Aeroporto
    - Entreposto comercial
    - Transporte rápido
    - Armazena aviões

###### Distritos que talvez entrem no jogo
- Entretenimento(?)
- Bairro Residencial(?)
- Espaçoporto(?)

##### Lista de Maravilhas

Posteriormente eu tenho que definir os bônus de cada maravilha.

- Pirâmides
- Grande Biblioteca
- Grande Farol de Alexandria
- Colosso de Rhodes
- Mausoléu de Helicarnassus
- Jardins Suspensos da Babilônia
- Estátua de Zeus
- Templo de Artemis
- Stonehenge
- Grande Muralha da China
- Torre Eifel
- Cristo Redentor
- Torre de Pisa
- Machu Pichu
- Chichén-Itzá

##### Lista de Melhorias

- Fazenda:
    - +2 de alimentos
    - Bônus de adjacência externo: +1 de alimentos.
    - Requisito de terreno: planícies

- Mina
    - +2 de produção
    - Bônus de adjacência externo: +1 de produção.
    - Requisito de terreno: colinas

- Plantação
    - +1 de ouro
    - +1 de alimentos
    - Bônus de adjacência externo: +1 de ouro.
    - Requisito de terreno: recursos de plantação

- Mina de recurso de luxo
    - +1 de ouro
    - +1 de produção
    - Bônus de adjacência externo: +1 de ouro.
    - Requisito de terreno: recursos de luxo e mineração

- Pasto e Acampamento
    - +1 de alimento
    - +1 de produção
    - Bônus de adjacência externo: +1 de alimentação.
    - Requisito de terreno: recursos de pasto ou acampamento

- Serraria
    - +1 de alimento
    - +1 de ciência
    - Bônus de adjacência externo: +1 de ouro.
    - Requisito de terreno: floresta

- Barco de Pesca
    - +2 de alimento
    - +1 de ouro
    - Bônus de adjacência externo: +1 de ouro.
    - Requisito de terreno: recurso marítmo no mar

- Trading Post/Entreposto comercial(Pode ser uma melhoria e também pode ser uma construção que já vem por padrão quando se constrói um porto ou um distrito comercial)
    - +2 de ouro
    - +1 de ouro pra cada rota comercial(interna ou externa) que passar por esse entreposto comercial
    - Bônus de adjacência externo: +1 de ouro.
    - Redução no custo de movimento
    - A estratégia pra essa melhoria pode ser voltada pro jogo wide ou pro jogo esparse. Impérios muito longos podem ter trading posts pra tanto ajudar na produção de ouro, como pra diminuir custos de movimento de tropas.

- Estrada
    - Corta o custo de movimento
    - Permite existência de rotas comerciais

- Limpar Floresta/Selva/Pântano
    - Corta o custo de movimento no terreno.
    - Gera produção bônus

- Forte
    - Dá bônus de defesa

#### Slots de cidadão

Cada nível de população que uma cidade conseguir chegar, libera um slot de cidadão para aquela cidade.
O slot de cidadão libera cidadãos para serem alocados em determinadas funções no império.

Por exemplo, um cidadão pode ser alocado pra ser cientista no campus da cidade.
Assim ele vai gerar mais ciência para a cidade e fazer as construções do campus gerarem mais ciência.

Um cidadão pode ser alocado pra ser um agricultor numa fazenda.
Assim, ele vai fazer a fazenda gerar mais comida.

Ele também pode ser alocado pra ser um soldado do império.
Tropas militares só podem ser criadas se existirem slots de população disponíveis.

Cada slot de cidadão equivale a um nível de população.
Não há como conseguir slots extras.

### 3.2 Recursos

Recursos são gerados junto com o mapa e estão distribuídos por aí.

Recursos, se forem trabalhados, adicionam bônus aos campos tradicionais.
Além disso, recursos podem servir de pré-requisito para construção de certas coisas.
Por exemplo: Navios industriais podem precisar de ferro e carvão.

Recursos são divididos em:
- Estratégico: bônus de produção e servem de base para produção de unidades.
- Bônus: bônus de alimento e produção.
- Luxo: bônus de ouro e fé.

#### Lista de Recursos

- Estratégico
    - Cobre
    - Ferro
    - Cavalo
    - Carvão
    - Petróleo
    - Urânio
    - Alumínio

- Bônus
    - Arroz
    - Gado
    - Banana
    - Cervo
    - Pedra
    - Peixe
    - Trigo

- Luxo
    - Açúcar
    - Ouro
    - Prata
    - Pérolas
    - Seda
    - Especiarias
    - Tintas

### 3.3 - Unidades

As unidades são geradas pelo jogador e podem agir no mapa
Via de regra, uma unidade pode ser: militar ou civil.
Elas podem se mover e alterar o estado do mapa.

Unidades militares podem se mover e se posicionar no mapa.
Unidades civis também podem.

#### Lista de unidades militares
- Meelee
- Heavy Cavalry
- Light Cavalry
- Anti Cavalry
- Ranged
- Naval Meelee
- Naval Ranged

Cada unidade militar possui alguns atributos:
- Força de combate(Attack)
- Saúde(Health Points)
- Modificadores(modificadores de experiência, terreno, dentre outros)

Unidades militares podem: atacar outras unidades, pilhar construções, proteger uma cidade, tomar uma cidade de assalto.

A unidade militar ocupa um slot de habitação, igual qualquer outra unidade dentro do jogo.
Além disso, uma unidade militar também tem custo de manutenção(em ouro).

Porém uma unidade militar pode ser melhorada com o passar do tempo, através de:
    - Vitórias em combate
    - Avanços tecnológicos

Uma unidade pode ter seus atributos melhorados através do mecanismo de experiência, ganho após vitórias e sobreviência em combates.
Uma unidade também pode ter seus atributos melhorados por conta de determinados investimentos feitos por uma mais cidade.
Se uma cidade quiser produzir "Armas melhores", ela vai aumentar a força dos guerreiros em alguns pontos.

Por fim, com o passar das eras, as unidades também podem sofrer _upgrades_.
Os upgrades são pagos em ouro ou produção.

Upgrades de tropas

- Cada tipo de tropa tem uma escala de níveis que corresponde a uma era de jogo.
Por exemplo, unidades militares meelee podem ser:
    - Guerreiro, na era antiga
    - Espadachim, na era clássica
    - Mosqueteiro, na era renascença
    - Infantaria, na era moderna
    - Infantaria mecanizada, na era da informação

Conforme o jogo avança, a tropa pode sofrer upgrade e aí com isso, aumentar seus atributos base.
Contudo, ao decorrer do jogo, um jogador pode escolhar melhorar os modificadores de suas tropas.

Por exemplo, um soldado meelee, tem espaço pra 5 níveis de evolução.
Cada nível de evolução pode dar benefícios como:
- +10% de ATTACK
- +15% de HEALTH
- +1 de movimento
- Bônus de cura
- First Strike
- Double Strike
- Ignorar remoção de movimento de terreno
- Ignorar supressão dos adversários
- Bônus defendendo

Observação: Mas aí talvez seja interessante em pensar numa progressão que seja a seguinte:
Uma unidade full upada consegue facilmente destruir uma unidade normal da sua era.
Mas uma unidade full upada consegue 50-50 destruir uma unidade normal de uma era acima.

Ou seja, upar as unidades é uma estratégia boa, desde que você seja capaz de manter elas atualizadas também.
Mas se você estiver atrás na corrida tecnologica, você pode escolher upar suas unidades pra pelo menos conseguir se defender decentemente enquanto busca outras alternativas pra ganhar o jogo ou pra alcançar seus adversários.

#### Civis
- Colono: constrói cidades
- Cientista: +2 de ciência, dá bônus
- Mercador: +2 de ouro, faz rotas comerciais
- Engenheiro: +2 de produção, dá bônus pra produção de determinados tipo de coisas
- Sacerdote: +2 de fé
- Artista: +2 de cultura
- Trabalhador: +1 de ouro/produção/alimento

Unidades civis também consomem um slot de população ao serem criadas.
O slot consumido é o slot da própria cidade em que elas foram criadas.

O jogador pode, posteriormente, mover uma unidade de uma cidade para a outra.
Mas apenas se a cidade-alvo tiver slot disponível.

A unidade civil, junto dos distritos, serve para dar foco a uma cidade.
Um cidadão **cientista** vai servir pra aumentar a produção de ciência na cidade.
Cada cientista oferece um bônus de produção de ciência para ser adicionado na produção base de ciência.
E por aí vai, pra cada tipo de cidadão.

Além disso, uma unidade civil terá a oportunidade de ser evoluída, tal qual uma unidade militar.

Um exemplo de promoção: quando uma tecnologia for pesquisada, ao invés do excedente de ciência ser alocado para a próxima tecnologia, você ganha aquele valor de ciência em ouro.

Aí acho que dá pra fazer as promoções das unidades civis acontecerem em grupo.

Por exemplo:
```
Colonos

- Funda a cidade com +1 habitante
- +1 de movimento no mar
- Ganha um distrito ao fundar a cidade
```

### 3.4 Fé e satisfação

A Fé representa o quanto os habitantes de um império acreditam no seu líder e no seu governo.

Uma cidade com muita fé aceitará melhor as condições impostas pelo governo.
Uma cidade com pouca fé não aceitará tão bem as condições impostas e pode vir a se rebelar contra o governo.

Inicialmente, uma cidade com pouca fé vai sofrer de falta de produtividade.
Uma cidade com fé negativa pode ter, por exemplo, -15% de produção.
Se a cidade ficar com pouca fé durante muito tempo, a população vai ficando insatisfeita até se rebelar e aí organizar uma revolta ou uma revolução.
Outros fatores, como crises econômicas e falta de alimentos podem gerar instatisfação das pessoas.

A felicidade/satisfação das pessoas é medida numa escala que vai de 1 a 10.

Valores     | Consequêncas
---         | ---
8, 9, 10    | Estado de felicidade. +10/15% de produção e crescimento na cidade
6, 7        | Estado normal. Sem modificadores
4, 5        | Estado de infelicidade,  -10%/15% de produção e crescimento na cidade
1, 2, 3     | Estado de calamidade. -20%/-25%/30%  de produção e crescimento na cidade. A cidade progressivamente vai perdendo slots pra serem usados pela cidade.

### 3.5 Revoltas
Revoltas danificam construções e melhorias.
Revoltas causam dano nas tropas ao redor da cidade.
Revoltas, se não forem contidas, podem causar revoluções e golpes.

Numa revolução, os slots de população do jogador vão se convertendo em slots de revolucionários, que por sua vez, são usados para gerar tropas revolucionárias.
Os revolucionários vão atacar o jogador e caso o jogador perca sua capital pros revolucionários, ele perde o jogo.
Ele deve manter a economia estável pra impedir crises econômicas.
E deve manter a produção estável pra continuar produzindo coisas.

Os Slots são perdidos de maneira que unidades civis são convertidas primeiro para os revolucionários.
Ao perder um slot, o jogador perde a unidade que ocupava aquela Slot.
O jogo primeiro vai converter as unidades civis.
Mas se o jogador não conseguir conter a revolta, o jogo vai converter unidades militares.
E aí o jogador, além de perder o slot, também vai perder a tropa pra cidade rebelde.

Se os rebeldes conseguirem tomar o controle da cidade e não quiserem se juntar a nenhum aliado, uma nova cidade-estado é criada no jogo.

Uma cidade em revolta, vai impactar cidades próximas a ela.
Redução de fé e de satisfação podem acontecer nessas cidades vizinhas.
Assim, uma revolta não contida pode ser perigosa: o jogador pode perder uma cidade e posteriormente ir perdendo, uma a uma, todo o seu império.

### 3.6 Combate

Unidades militares podem se enfrentar em qualquer lugar do mapa.
Basicamente uma unidade militar possui dois atributos principais: o valor de ataque, ATTACK POINTS e o valor de defesa, HEALTH POINTS.
Além disso, cada unidade pode ter modificadores, que afetam esses valores dado determinadas condições.

Uma unidade é destruída se sua vida(health) chegar a 0.

No combate, as duas unidades trocam dano entre si.

Cada unidade possui um valor de ataque e outro de vida.
E os dois atributos se relacionam entre si.

Uma unidade que recebeu muito dano e está com  a vida comprometida, também vai dar menos dano no seu próximo ataque.
Já uma unidade com a vida cheia, vai dar o seu dano total num próximo ataque.

// Falta definir:
// - Como ficaria o sistema de redução de dano, com base na vida

#### 3.7 Condição de vitória

- Científica
- Cultural
- Dominação

##### Científica

> Por toda a história, você estudou como o universo funcionava.
> Agora voce está pronto para abandonar seu mundo de origem e conquistar novos.

A vitória científica, premia infraestrutura e o foco em ciência.
Pra ganhar pela vitória científica, o jogador deve sobreviver ao jogo e construir um império organizado o suficiente para lançar um foguete rumo à planetas habitáveis antes de todos os outros jogadores ganharem o jogo.

Se você construir um império robusto, capaz de resistir a agressões militares, capaz de se manter estável financeiramente e capaz de manter a coesão dos cidadãos, você pode mirar na vitória científica.

##### Cultural

> Você dominou o mundo inteiro, mas não com sua força.
> E sim com seu conhecimento e com suas ideias.
> Toda a humanidade copia os hábitos do seu império e as pessoas sonham em serem como você.

Se você construir um império robusto, capaz de resistir a agressões militares, capaz de se manter estável financeiramente e capaz de manter a fé dos cidadãos, você pode mirar na vitória cultural.

Na vitória cultural, o jogador deve voltar seus esforços para fazer sua civilização ser uma referencia para todos os povos do mundo.
Isso se torna possível se ele alcançar o nível máximo de influência cultural em todas as civilizações do jogo.

##### Dominação

> Você dominou o mundo inteiro com sua força absoluta.
> Toda a humanidade está submissa as decisões que vêem do seu palácio.

Na vitória por dominação, o jogador deve voltar seus esforços pra fazer sua civilização conquistar todas as capitais de todas as civilizações.

##### Diplomática

> Por toda a história da humanidade, você foi aquele que preferia o diálogo ao conflito.
> Assim, você uniu o mundo inteiro em um só governo.
> Toda a humanidade respeita a sua liderança e acredita que você será capaz de tomar as melhores decisões daqui pra frente, rumo a um futuro glorioso.

Na vitória diplomática, o jogador deve conseguir fazer todas as civilizações integrarem uma organização supra-estatal, que abrange todas as civilizações e cidades do jogo.

#### 3.8 Condição de derrota

Um jogador perde o jogo se:
- Outro jogador ganhar antes dele
- Ele perder a capital, tanto para algum adversário, como para próprios cidadãos revoltosos
#### 3.9 Anotações no mapa

Durante o jogo, o jogador poderá fazer anotações no mapa e definir lembretes.
Tudo isso será acionado com o botão direito do mouse.

Se o jogador clica com o botão direito do mouse num hexágono no mapa, abre um menu com as seguintes opções:
- Criar nota
- Editar nota
- Deletar nota

Com isso, o jogador pode fazer uma anotação ou uma marcação ali. Por exemplo, pode marcar que pretende fazer uma cidade naquele hexágono.

Depois que ele termina, ele vê cada nota minimizada no próprio mapa.
Se ele quiser ver o conteúdo de cada nota, ele pode clicar no ícone da nota no mapa.

Ao clicar no ícone da nota no mapa, ele pode editar ou apagar a nota.

## 4. Habilidades do jogador

Espera-se que o jogador seja capaz:
- Analisar informações do estado do jogo e tomar decisões
- Planejar estratégias em antecipação
- Reagir a eventos externos(jogadas de outros jogadores)
- Usar o mouse pra clicar em opções
- User o teclado para moviemntar câmera e usar os atalhos do jogo.

## 5. Identidade visual do jogo

O mapa de jogo, em si, pode assumir um visual que diz respeito a cada época sendo representada no jogo.
Mas os menus podem assumir uma identidade mais moderna durante todo o jogo.

Botões retangulares e retos, sem borda e sem sombra.
Fontes com serifa, bem espaçadas.

A cor de fundo dos menus pode ser um azul escuro, e a fonte, branca.

Seguir padrões na componentização do jogo.
Exemplo: Árvore de Tecnologia e Cívicos pode ser idêntica.

Tela com as promoções de cada unidade também.
Aí a tela de escolha dos cards de promoção pode ser igual à tela de visualização dos cards escolhidos.

## 6. Fluxos do usuário

- Jogo Novo: Menu -> Jogar -> Criar Partida(define as configurações) -> Jogar
- Carregar jogo existente: Menu -> Jogar -> Carregar Partida -> Jogar
- Visualizar estatísticas: Menu -> Leaderboard
- Visualizar Civilopedia: Menu -> Civilopedia
- Sair: Menu -> Sair


## 7. Plataformas
    - Sistema Operacional: Windows
    - Entrada: Mouse e Teclado
