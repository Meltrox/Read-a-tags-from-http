let url2Stream url = 
    let url = System.Uri url
    let request = System.Net.WebRequest.Create url
    let response = request.GetResponse()
    response.GetResponseStream()

let readUrl url = 
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd()

let matchString = "<a href"
let urlString = readUrl "https://www.valutakurser.dk/"
let countLinks (str : string) =
    let mutable counter = 0
    for i in 0..(str.Length - matchString.Length) do
        if str.[i..(i+6)] = matchString then
            counter <- counter + 1
        else
            ()
    counter
printfn "%A" (countLinks urlString)