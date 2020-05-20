import lib.Helpers;

public class Main {
    public static void main(String[] args) {
        if(args.length != 1){
            System.out.print("This app requires one argument to start.");
            System.exit(1);
        }
        String category = args[0];
        if(!Helpers.isValidCategory(category)){
           // System.out.print("This app requires one valid argument to start. The category options are - {0}", string.Join(" | ", Constants.ALLOWED_CATEGORIES));
        }
    }
}