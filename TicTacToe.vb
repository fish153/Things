
'Write a Tic-Tac-Toe game that allows you to play against the computer. 
'Instead of x and y, we will use 1 and 2. You will need a 3x3 array to hold the information. 
'You will be ‘1’ and the computer will by ‘2’. The computer’s coordinate will be generated through a random number generator. 
'If the user or the computer selects a coordinate that was previously selected, then either ask the user or have the computer generate another number. 
'The game should stop as soon as there is a win. Display the grid after the computer or the user has selected the coordinate. 
'If there is a tie, erase the grid and re-start the game until there is a win.

'Your program should have the following methods
'	displayGrid
'	inputUser
'	inputComputer
'	alreadyTaken



Module TicTacToe
    Dim randomObject As New Random() ' seed random generator

    Sub Main()

        Dim game(2, 2) As String ' array keeps moves
        Dim counter As Integer = 0
        Do
            Console.WriteLine("     Tic-Tac-Toe")
            Console.WriteLine("Author: Kanstantsin Kubrak")
            Populate(game) ' populate array with digits from 1 to 9
            DisplayGrid(game) ' show grid
            Do

                InputUser(game)
                counter += 1 ' count each move - by the user and by the computer

                ' because user starts first, 9th move is by the user, so here is if statement to avoid 10th move by the computer
                If counter < 9 Then
                    InputComputer(game)
                    counter += 1

                End If
                DisplayGrid(game)
            Loop Until counter = 9 Or Won(game)
        Loop Until Won(game)


        Console.ReadKey()
    End Sub

    ' populate array with numbers from 1 to 9
    Sub Populate(ByRef game(,) As String)
        Dim register As Integer = 1

        For r As Integer = 0 To 2
            For c As Integer = 0 To 2

                game(r, c) = register
                register += 1
            Next
        Next
    End Sub
    ' user makes move
    Sub InputUser(ByRef game(,) As String)
        Dim move As Integer ' position of user's move

        Do
            Console.Write("Your move: ")
            move = Console.ReadLine() ' get the position as a number from 1 to 9

        Loop While AlreadyTaken(game, Position(move)(0), Position(move)(1)) ' check if the position is taken
        game(Position(move)(0), Position(move)(1)) = "o" ' assign  o to the position in the array taken by the user

    End Sub
    ' computer move is randomly generated
    Sub InputComputer(ByRef game(,) As String)
        Dim move As Integer
        Do
            move = randomObject.Next(1, 10) ' get a random number

        Loop While AlreadyTaken(game, Position(move)(0), Position(move)(1)) ' chekc if the position is taken
        Console.WriteLine("Computer's move: " & move & vbCrLf) ' show computer's move
        game(Position(move)(0), Position(move)(1)) = "x" 'assign x to the position in the array randomly chosen
    End Sub
    ' draw the game grid
    Sub DisplayGrid(ByRef game(,) As String)
        Dim indent As String = vbTab & vbTab
        For row As Integer = 0 To 2
            Console.Write(indent)
            For column As Integer = 0 To 2
                Console.Write(game(row, column)) 'print the content of the array
                ' don't print third vertical bar
                If column < 2 Then
                    Console.Write("|")
                End If
            Next
            Console.Write(vbCrLf)
            ' print only two lines
            If row < 2 Then
                Console.WriteLine(indent & "_ _ _")
            End If
        Next
        ' print a devider
        Console.WriteLine(vbCrLf & "+ + + + + + + +")
    End Sub
    ' take position, return coordinates - an array with to numbers
    Function Position(ByVal move As Integer)
        Dim square(1) As Integer
        Dim row As Integer
        Dim column As Integer
        Select Case move
            Case 1
                row = 0
                column = 0
            Case 2
                row = 0
                column = 1
            Case 3
                row = 0
                column = 2
            Case 4
                row = 1
                column = 0
            Case 5
                row = 1
                column = 1
            Case 6
                row = 1
                column = 2
            Case 7
                row = 2
                column = 0
            Case 8
                row = 2
                column = 1
            Case 9
                row = 2
                column = 2
        End Select
        square(0) = row
        square(1) = column
        Return square
    End Function

    ' check if the position already taken, return False if it's empty
    Function AlreadyTaken(ByRef game(,) As String, ByVal row As Integer, ByVal column As Integer) As Boolean
        Dim valid As Boolean = False
        If game(row, column) = "o" Or game(row, column) = "x" Then
            valid = True
        End If
        Return valid
    End Function
    ' check if there is a winning combination, print who is the winner
    Function Won(ByRef game(,) As String) As Boolean
        Dim victory = False ' returned value,
        Dim c As Integer = 0
        ' for loop goes through horizontal and vertical lines
        For r As Integer = 0 To 2
            ' horizontal lines
            If game(r, c) = game(r, c + 1) And game(r, c + 1) = game(r, c + 2) Then
                If game(r, c) = "o" Then
                    victory = True
                    Console.WriteLine("You won")
                ElseIf game(r, c) = "x" Then
                    victory = True
                    Console.WriteLine("Computer won")
                End If
                ' vertical lines
            ElseIf game(c, r) = game(c + 1, r) And game(c + 1, r) = game(c + 2, r) Then
                If game(c, r) = "o" Then
                    victory = True
                    Console.WriteLine("You won")
                ElseIf game(c, r) = "x" Then
                    victory = True
                    Console.WriteLine("Computer won")
                End If
            End If

        Next
        ' diagonals 
        If game(0, 0) = game(1, 1) And game(1, 1) = game(2, 2) Then
            If game(0, 0) = "o" Then
                victory = True
                Console.WriteLine("You won")
            ElseIf game(0, 0) = "x" Then
                victory = True
                Console.WriteLine("Computer won")
            End If
        End If
        If game(0, 2) = game(1, 1) And game(1, 1) = game(2, 0) Then
            If game(0, 2) = "o" Then
                victory = True
                Console.WriteLine("You won")
            ElseIf game(0, 2) = "x" Then
                victory = True
                Console.WriteLine("Computer won")
            End If
        End If
        Return victory
    End Function
End Module
x
