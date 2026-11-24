public class InfoCard {
    private string title;
    private string text;

    public InfoCard(string title, string text){
        this.title = title;
        this.text = text;
    }

    public string GetTitle () {
        return title;
    }

    public string GetInformation(){
        return text;
    }
}