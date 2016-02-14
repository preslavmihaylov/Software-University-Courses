#include <linux/kernel.h>
#include <linux/module.h>
#include <linux/init.h>
#include <linux/proc_fs.h>
#include <linux/seq_file.h>

int X1 = 0;
int Y1 = 0;
int X2 = 0;
int Y2 = 0;
int X3 = 0;
int Y3 = 0;

module_param(X1, int, 0);
module_param(Y1, int, 0);
module_param(X2, int, 0);
module_param(Y2, int, 0);
module_param(X3, int, 0);
module_param(Y3, int, 0);

/*
static int int_sqrt(int num) {
	unsigned int square = 1;
	unsigned int delta = 3;
	while (square <= num) {
		square += delta;
		delta += 2;
	}

	return (delta / 2 - 1);
}
*/

static int distance(int x1, int y1, int x2, int y2) {
	int deltaX = x2 - x1;
	int deltaY = y2 - y1;
	int distance = int_sqrt(deltaX * deltaX + deltaY * deltaY);

	return distance;
}

static int calc_perimeter(int a, int b, int c) {
	return a + b + c;
}

static int calculate_triangle_metrics(struct seq_file *m, void *v) {
	int a = distance(X1, Y1, X2, Y2);
	int b = distance(X1, Y1, X3, Y3);
	int c = distance(X2, Y2, X3, Y3);
	int perimeter = calc_perimeter(a, b, c);
	seq_printf(m, "Perimeter: %d\n", perimeter);
	return 0;
}

static int triangle_open_proc(struct inode *inode, struct file *file) {
	return single_open(file, calculate_triangle_metrics, NULL);
}

struct proc_dir_entry * proc_file_entry;

static const struct file_operations proc_file_fops = {
	.owner = THIS_MODULE,
	.open = triangle_open_proc,
	.read = seq_read,
	.llseek = seq_lseek,
	.release = single_release
};

static int __init init(void) {
	proc_file_entry = proc_create("triangle", 0, NULL, &proc_file_fops);
	if (proc_file_entry == NULL) {
		return -ENOMEM;
	}

	return 0;
}

static void __exit clean(void) {
	remove_proc_entry("triangle", NULL);
}

module_init(init);
module_exit(clean);
