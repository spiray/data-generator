import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

import lib.Constants;
import lib.Helpers;

public class Main {
    public static void main(String[] args) {
        if (args.length != 1) {
            System.out.print("This app requires one argument to start.");
            System.exit(1);
        }

        String category = args[0];
        if (!Helpers.isValidCategory(category)) {
            System.out.print(
                    String.format("This app requires one valid argument to start. The category options are - %s\n",
                            String.join(" | ", Constants.ALLOWED_CATEGORIES)));
            System.exit(1);
        }

        File newDirectory = new File("data");
        if (!newDirectory.exists()) {
            newDirectory.mkdir();
        }

        try {
            String data = Helpers.getJSONData(category);
            try (FileWriter fileWriter = new FileWriter(String.format("data/%s.json", category))) {
                fileWriter.write(data);
            }
        } catch (IOException e) {
            e.printStackTrace();
            System.exit(1);
        } catch (InterruptedException e) {
            e.printStackTrace();
            System.exit(1);
        }

        System.out.print(String.format("Check out your %s data @ /data/%s.json\n",
                category.substring(0, category.length() - 1), category));
        System.exit(0);
    }
}