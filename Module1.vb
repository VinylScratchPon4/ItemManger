Module Module1

    'Initalising Variables
    Dim Name(9), Comd, Names, CName, Amount(9), Amounts, CAmount As String
    Dim Slot, Buy As Integer
    Dim Write As System.IO.StreamWriter
    Dim Read As System.IO.StreamReader
    Dim Price(9), CPrice As Double


    'Read the text files with the information
    Sub ReadDisplay()
        Read = My.Computer.FileSystem.OpenTextFileReader("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data.txt")

        For i = 0 To 9
            Name(i) = Read.ReadLine()
        Next

        Read.Close()

        Read = My.Computer.FileSystem.OpenTextFileReader("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data1.txt")

        For i = 0 To 9
            Amount(i) = Read.ReadLine()
        Next

        Read.Close()

        Read = My.Computer.FileSystem.OpenTextFileReader("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data2.txt")

        For i = 0 To 9
            Price(i) = Read.ReadLine()
        Next

        Read.Close()
    End Sub

    'Display all of the data
    Sub Display()
        Console.Clear()
        Console.WriteLine("No| Name | Amount | Price")
        For i = 0 To 9
            Console.WriteLine(i + 1 & " | " & Name(i) & " | " & Amount(i) & " | " & "£" & Price(i))
        Next

    End Sub


    Sub Main()

        'Read and Display
        ReadDisplay()
        Display()

        Read = My.Computer.FileSystem.OpenTextFileReader("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data1.txt")

        'Getting Names
        For i = 0 To 9
            Amount(i) = Read.ReadLine()

        Next

        Read.Close()

        Console.WriteLine("")
        'The main loop
        While True
            'Get the command
            Comd = Console.ReadLine()

            'If the user types edit
            Select Case Comd
                Case "edit"

                    Console.WriteLine("Would you like to edit:")
                    Console.WriteLine("1. Name")
                    Console.WriteLine("2. Amount")
                    Console.WriteLine("3. Price")
                    Console.Write(">>:")
                    Comd = Console.ReadLine()

                    Select Case Comd
                        'If they select 1
                        Case 1

                            Console.Write("Which slot would you like to edit? ")
                            Slot = Int(Console.ReadLine() - 1)
                            Console.Write("What would you like to change the name to? ")
                            CName = Console.ReadLine()
                            Name(Slot) = CName
                            Console.WriteLine(Name(4))

                        'If they select 2
                        Case 2
                            Console.Write("Which slot would you like to edit?")
                            Slot = Int(Console.ReadLine() - 1)
                            Console.Write("What is the amount?")
                            CAmount = Console.ReadLine()
                            Amount(Slot) = CAmount
                        Case 3
                            Console.Write("Which slot would you like to edit?")
                            Slot = Int(Console.ReadLine() - 1)
                            Console.Write("What is the price? £")
                            CPrice = CDbl(Console.ReadLine())
                            Price(Slot) = CPrice

                    End Select

                    'If the user types save
                Case "save"

                    'If the file exists delete it
                    If My.Computer.FileSystem.FileExists("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data.txt") Then
                        My.Computer.FileSystem.DeleteFile("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data.txt")
                    End If

                    'Open files
                    Write = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data.txt", True)

                    'Change the variables to the saved document
                    For i = 0 To 9
                        Write.WriteLine(Name(i))
                    Next

                    'Close
                    Write.WriteLine(Name)
                    Write.Close()

                    'If the file exists delete it
                    If My.Computer.FileSystem.FileExists("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data1.txt") Then
                        My.Computer.FileSystem.DeleteFile("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data1.txt")

                    End If

                    'Open the document
                    Write = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data1.txt", True)

                    'change the variables to the saved document
                    For i = 0 To 9
                        Write.WriteLine(Amount(i))
                    Next

                    'Close
                    Write.WriteLine(Amount)
                    Write.Close()


                    If My.Computer.FileSystem.FileExists("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data2.txt") Then
                        My.Computer.FileSystem.DeleteFile("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data2.txt")

                    End If

                    'Open the document
                    Write = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\zakbo\Documents\Coding\C#\Testing\ConsoleApplication\ConsoleApplication\data2.txt", True)

                    'change the variables to the saved document
                    For i = 0 To 9
                        Write.WriteLine(Price(i))
                    Next

                    'Close
                    Write.WriteLine(Amount)
                    Write.Close()



                    'If the user types quit
                Case "quit"

                    Environment.Exit(0)
                Case "clear"
                    Console.Clear()

                Case "help"
                    Console.Clear()
                    Console.WriteLine("This is an item manager")
                    Console.WriteLine("To add/edit an item type 'edit' and then type acordingly")
                    Console.WriteLine("edit - edit price/name/amount")
                    Console.WriteLine("save - save your changes for the next time you run this application")
                    Console.WriteLine("quit - closes the application")
                    Console.WriteLine("clear - clears the console")
                    Console.WriteLine("help - shows this menu")
                    Console.WriteLine("buy - buys a specified amount of an item")
                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()
                    Console.Clear()

                Case "buy"
                    Console.Write("Item Slot?")
                    Slot = Int(Console.ReadLine()) - 1
                    Console.Write("Amount?")
                    Buy = Int(Console.ReadLine())

                    Amount(Slot) = Amount(Slot) - Buy


            End Select



            Display()

        End While

    End Sub

End Module

